    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            string S = "\nHello and welcom choose one\n response\r\n1:response1\r\n2:choice number 2\r\n3:The Third choice\nin the list\r\n4:You can choose the last response.\n";
            Console.WriteLine(GetNumber (S, "last"));
            Console.WriteLine(GetNumber (S, "bla bla"));
        }
        
        private static string GetNumber(string inputText, string match)
        {
            string pattern = @".*(\d):.*?" + match;
            Regex myRegex = new Regex(pattern, RegexOptions.None);
           
            foreach (Match myMatch in myRegex.Matches(inputText))
            {
              if (myMatch.Success)
              {
                 return myMatch.Groups[1].Value;
              }
            }
            
            return "0";
        }
    }
