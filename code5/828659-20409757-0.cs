    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System;
    
     public class Example
    {
       public static void Main()
       {
            string str = @"a,,,b,c,,,,d";
            Regex pattern = new Regex(@",,");
            string replacement = @",null,";
            Match m = pattern.Match(str);
            while (m.Success)
            {
                str = pattern.Replace(str, replacement);
                m = pattern.Match(str);
            }
            
            Console.WriteLine(str);
        }
    }
