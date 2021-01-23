    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main() {
    var myRegex = new Regex(@"(?s)(\A.*?)<p>.*?</p>");
    string s1 = @"Hey! <p>Hello</p> <p>World</p>";
         
    string replaced = myRegex.Replace(s1, delegate(Match m) {
    return m.Groups[1].Value;
    });
    Console.WriteLine("\n" + "*** Replacements ***");
    Console.WriteLine(replaced);
         
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
         
    } // END Main
    } // END Program
