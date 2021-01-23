    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program {
    
    static void Main() {
    string s1 = @" ["" my beautiful string "", ["" my second string "", ";
    var resultList = new StringCollection();
    try {
    	var myRegex = new Regex(@"\["".*?"",", RegexOptions.Multiline);
    	Match matchResult = myRegex.Match(s1);
    	while (matchResult.Success) {
    		resultList.Add(matchResult.Groups[0].Value);
    		Console.WriteLine(matchResult.Groups[0].Value);
    		matchResult = matchResult.NextMatch();
    	} 
    } catch (ArgumentException ex) {
    	// Syntax error in the regular expression
    }
    
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    } // END Main
    } // END Program
