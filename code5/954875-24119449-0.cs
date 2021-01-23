    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main()  {
    string s1 = @"want to find this text
    <p>I don't want to find this text</p>
    I want to find this text";
    var myRegex = new Regex(@"(?i)<(\w+).*?<\/\1[^>]*>|([a-z][a-z ]+)");
    var group1Caps = new StringCollection();
        
    Match matchResult = myRegex.Match(s1);
    // put Group 2 captures in a list
    while (matchResult.Success) {
       if (matchResult.Groups[2].Value != "") {
            group1Caps.Add(matchResult.Groups[2].Value);
            }
      matchResult = matchResult.NextMatch();
    }
    
    Console.WriteLine("\n" + "*** Matches ***");
    if (group1Caps.Count > 0) {
       foreach (string match in group1Caps) Console.WriteLine(match);
       }
    
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    
    } // END Main
    } // END Program
