    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program {
    
    static void Main() {
    string yourstring = @"1.1 - Hello
    1.2 - world!
    2.1 - Some
    data
    here and it contains some 32 digits so i cannot use \D+
    2.2 - Etc..";
    var resultList = new StringCollection();
    try {
    	var yourRegex = new Regex(@"(?sm)^\d+\.\d+\s*-\s*((?:.(?!^\d+\.\d+))*)");
    	Match matchResult = yourRegex.Match(yourstring);
    	while (matchResult.Success) {
    		resultList.Add(matchResult.Groups[1].Value);
    		Console.WriteLine(matchResult.Groups[1].Value);
    		matchResult = matchResult.NextMatch();
    	} 
    } catch (ArgumentException ex) {
    	// Syntax error in the regular expression
    }
    
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    } // END Main
    } // END Program
