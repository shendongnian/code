    using System;
    using System.Text.RegularExpressions;
    class Program {
    static void Main() {
    
    string s1 = "<tr stuff>Catch Me</tr>";
    var r = new Regex("(?i)<tr[^>]*?>([^<]*)</tr>");
    string capture = r.Match(s1).Groups[1].Value;
    Console.WriteLine(capture);
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    } // END Main
    } // END Program
