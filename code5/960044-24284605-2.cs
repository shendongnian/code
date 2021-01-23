    using System;
    using System.Text.RegularExpressions;
    class Program
    {
    static void Main() {
    var myRegex = new Regex(@"(?s)(\A.*?)<p>.*?</p>");
    string s1 = @"Hey! <p>Hello</p> <p>World</p>";
         
    string replaced = myRegex.Replace(s1, delegate(Match m) {
    return m.Groups[1].Value;
    });
    Console.WriteLine(replaced);
         
    } // END Main
    } // END Program
