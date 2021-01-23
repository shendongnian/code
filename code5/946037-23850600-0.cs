    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program {
    static void Main()    {
    string s1 = @"<option value=""USD"">American Samoa, United States Dollar (USD)</option>
    <option value=""EUR"">Andorra, Euro (EUR)</option>
    <option value=""AOA"">Angola, Kwanza (AOA)</option>
    <option value=""XCD"">Anguilla, East Caribbean Dollar (XCD)</option>
    <option value=""XCD"">Antigua and Barbuda, East Caribbean Dollar (XCD)</option>
    <option value=""ARS"">Argentina, Peso (ARS)</option>";
    var myRegex = new Regex(@"<option value=""[A-Z]{3}""[^<]*</option>");
    MatchCollection AllMatches = myRegex.Matches(s1);
    
    Console.WriteLine("\n" + "*** Matches ***");
    if (AllMatches.Count > 0)    {
        foreach (Match SomeMatch in AllMatches)    {
            Console.WriteLine("Overall Match: " + SomeMatch.Value);
                }
    }
    
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
    } // END Main
    } // END Program
