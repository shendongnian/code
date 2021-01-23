    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main() {
    string s1 = @"with System, System.IO, System.Text";
    var myRegex = new Regex(@"(?:with\s|\G)([^,]*)(?:,\s*|$)");
    var group1Caps = new StringCollection();
     
    Match matchResult = myRegex.Match(s1);
    // put Group 1 captures in a list
    while (matchResult.Success) {
    if (matchResult.Groups[1].Value != "") {
    group1Caps.Add(matchResult.Groups[1].Value);
    }
    matchResult = matchResult.NextMatch();
    }
     
    string usingStr  = "";
    foreach (string match in group1Caps) usingStr = usingStr + "Using " + match + ";\n";
    Console.WriteLine(usingStr);
    
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
     
    } // END Main
    } // END Program
