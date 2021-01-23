    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main()  {
    var myRegex = new Regex(@"IgnoreFunction\s*(['""])[^']*\1|AlsoIgnoreFunction\[[^\]]*\]|(ANDALSO|ORELSE)");
    string s1 = @"SomeVar ANDALSO SomeOTherVar ANDALSO AnotherVar = 1234 IgnoreFunction 'SomeVar=ANDALSO AnotherVar'
    AlsoIgnoreFunction['test=value', 'anotherTest = ANDALSO anotherValue'] ORELSE ANDALSO";
    
    string replaced = myRegex.Replace(s1, delegate(Match m) {
        if (m.Groups[2].Value == "ANDALSO") return "&&";
        else if (m.Groups[2].Value == "ORELSE") return "||";
        else return m.Value;
        });
    Console.WriteLine("\n" + "*** Replacements ***");
    Console.WriteLine(replaced);
    
    
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    
    } // END Main
    } // END Program
