    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            string input = "arjunmenon.uking";
            string pattern = @"[a-zA-Z0-9].*\.([a-zA-Z0-9].*)";
            
            foreach (Match match in Regex.Matches(input, pattern))
           {
             Console.WriteLine(match.Value);
             if (match.Groups.Count > 1)
                for (int ctr = 1; ctr < match.Groups.Count; ctr++) 
                   Console.WriteLine("   Group {0}: {1}", ctr, match.Groups[ctr].Value);
          }
           
        }
    }
    Result:
    arjunmenon.uking
        Group 1: uking
