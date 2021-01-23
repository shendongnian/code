    using ConsoleApplication3;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public static class Program
    {
    
        private static void Main(string[] args)
        {
    
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("c:\\temp\\test.txt");
            var line = string.Empty;
    
            string fileData = file.ReadToEnd();
            file.Close();
    
            fileData = "newword".InsertSkip(fileData);
    
            StreamWriter fileWrite = new StreamWriter(@"C:\temp\test.txt", false);
            fileWrite.Write(fileData);
            fileWrite.Flush();
            fileWrite.Close();
    
        }
    
        public static string InsertSkip(this string word, string data)
        {
            var regMatch = @"\b(" + word + @")\b";
            Match result = Regex.Match(data, regMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            if (result == null || result.Length == 0)
            {
                data += Environment.NewLine + word;
            }
            return data;
        }
    }
