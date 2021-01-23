    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        static void Main()
        {
            string input = "My markup file <title value=\"The title\" /> and more text and another title <title value=\"XXX\" />The <text> blah blah blah";
            
            Console.WriteLine(ReplaceTitle(input, "NEWTITLE"));        
        }
        
        public static string ReplaceTitle(string input, string newTitle)
        {
            string findPattern = @"(?<prepend><title\s+value\s*=\s*\"")([^\""]*)(?<append>\"")";
            string replacePattern = "${prepend}" + newTitle + "${append}";
    
            return Regex.Replace(input, findPattern, replacePattern, RegexOptions.IgnoreCase);
        }
    }
