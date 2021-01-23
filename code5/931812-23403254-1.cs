    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program {
    static void Main() {
    
    string s1 = @"
    Employee Smith 9785 22
    Department Matrix 8756 33
    Pet Dog 725 Labrador Snoopy
    Color Pink 550000 Flamingo
    ";
    
    StringCollection resultList = new StringCollection();
    try
    {
    Regex regexObj = new Regex(@"(?m)^\w+\s*(\w+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    Match matchResult = regexObj.Match(s1);
    while (matchResult.Success)
    {
    Console.WriteLine(matchResult.Groups[1].Value);
    resultList.Add(matchResult.Groups[1].Value);
    matchResult = matchResult.NextMatch();
    }
    }
    catch (ArgumentException ex)
    {
    // Syntax error in the regular expression
    }
    
    
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    } // END Main
    } // END Program
