    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program {
    static void Main()    {
    string s1 = @"PASTE YOUR STRING HERE";
    var myRegex = new Regex(@"(?s)~~~ START ([^~]*).*?END \1 ~~~");
    MatchCollection AllMatches = myRegex.Matches(s1);
    Console.WriteLine("\n" + "*** Matches ***");
    if (AllMatches.Count > 0)    {
        foreach (Match SomeMatch in AllMatches)    {
            Console.WriteLine("Title: " + SomeMatch.Groups[1].Value);
            Console.WriteLine("Overall Match: " + SomeMatch.Value);
        }
    }
    
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    
    } // END Main
    } // END Program
