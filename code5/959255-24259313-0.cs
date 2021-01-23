    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main() {
    var myRegex = new Regex(@"{[^}]*}|(#+)");
    string s1 = @"# {0}mm ####{1:0.##}mm ##x {2:0.##}mm";
     
    string replaced = myRegex.Replace(s1, delegate(Match m) {
    if (m.Groups[1].Value != "") return "";
    else return m.Value;
    });
    Console.WriteLine("\n" + "*** Replacements ***");
    Console.WriteLine(replaced);
     
     
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
     
    } // END Main
    } // END Program
