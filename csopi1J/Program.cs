using csopi1J;
using System.Linq;
using System.Text;

const string FILE = @"..\..\..\src\forras.txt";
const int EV = 2014;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new(FILE, Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyt befejezok szama: {versenyzok.Count} fo");

var f01 = versenyzok.Count(v => v.Kategoria == "elit");
Console.WriteLine($"versenyzok szama elit kategoriaban: {f01} fo");


var f02 = versenyzok.Where(v => !v.Nem).Average(v => EV - v.SzulEv);
Console.WriteLine($"női versenyzok atlageletkora: {f02:0.00} ev");


var f03 = versenyzok.Sum(v => v.VersenyIdok["Kerékpár"].TotalHours);
Console.WriteLine($"kerekparozassal toltott osszido: {f03:0.00} ora");

var f04 = versenyzok.Where(v => v.Kategoria == "elit junior").Average(v => v.VersenyIdok["Úszás"].TotalMinutes);
Console.WriteLine($"atlag elit junior uszas ido: {f04:0.00} perc");

var f05 = versenyzok.Where(v => v.Nem).MinBy(v => v.OsszIdo);
Console.WriteLine($"elosokent celba ero ferfi: {f05}");

var f06 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Count());
Console.WriteLine("a versenyt befejezok szama kategoriankent:");
foreach (var kvp in f06) Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value,2} fo");



var f07 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key)
    .ToDictionary(g => g.Key, g => g.Average(v => v.VersenyIdok["I. depó"].TotalMinutes+ v.VersenyIdok["II. depó"].TotalMinutes));
Console.WriteLine("atlag depoban toltott ido kategoriankent:");
foreach (var kvp in f07) Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value:0.00} perc");

Console.WriteLine("\n - - - -  csopi2  - - - - ");
// - - - -  csopi2  - - - - 
var c01 = versenyzok.Count(v => v.Kategoria == "elit junior");
Console.WriteLine($"elit juniorok száma: {c01}");


var c02 = versenyzok.Where(v => v.Nem).Average(v => EV - v.SzulEv);
Console.WriteLine($"férfi versenyzok atlageletkora: {c02:0.00} ev");


var c03 = versenyzok.Sum(v => v.VersenyIdok["Futás"].TotalHours);
Console.WriteLine($"futással töltött idő: {c03:0.00}");

var c04 = versenyzok.Where(v => v.Kategoria == "20-24" ).Average(v => v.VersenyIdok["Úszás"].TotalMinutes);
Console.WriteLine($"átlagos úszási idő 20-24 kategóriában: {c04:0.00} ");

var c05 = versenyzok.Where(x => !x.Nem).Min(x => x.OsszIdo);
string vki = string.Empty;
foreach (var item in versenyzok)
{
    if (item.OsszIdo == c05)
    {
        vki = item.Nev;
    }
}
Console.WriteLine($"női győztes: {vki}");

var s = versenyzok.Where(x => x.Nem).Count();
Console.WriteLine($"srácok: {s}");

var l = versenyzok.Where(x => !x.Nem).Count();
Console.WriteLine($"lányok: {l}");

Console.WriteLine("\n - - - -  csopi3  - - - - ");
// - - - -  csopi3  - - - - 

var cs01 = versenyzok.Where(x => x.Kategoria == "25-29").Count();
Console.WriteLine($"versenyzők száma 25-29 kategóriában: {cs01}");

var cs02 = versenyzok.Average(x =>  EV - x.SzulEv);
Console.WriteLine($"versenyzők átlagéletkora: {cs02}");

var cs03 = versenyzok.Sum(v => v.VersenyIdok["Úszás"].TotalHours);
Console.WriteLine($"a versenyzők úszással töltött összideje {cs03:00}");

var cs04 = versenyzok.Where(x => x.Kategoria == "elit").Average(x=> x.VersenyIdok["Úszás"].TotalHours);
Console.WriteLine($"átlagos úszási idő elit kategóriában {cs04}");

var cs05 = versenyzok.Where(x => x.Nem).Min(x => x.OsszIdo);
vki = string.Empty;
foreach (var item in versenyzok)
{
    if (item.OsszIdo == cs05)
    {
        vki = item.Nev;
    }
}
Console.WriteLine($"férfi győztes: {vki}");