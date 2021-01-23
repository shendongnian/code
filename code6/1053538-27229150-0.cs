    using System.IO;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tokens = new List<string>();
                foreach (string line in File.ReadAllLines("C:\\temp\\test.txt"))
                {
                    if (Regex.IsMatch(line, @"^\d\d/\d\d/\d\d\d\d \d\d:\d\d:\d\d"))
                    {
                        tokens.Add(line);
                    }
                    else
                    {
                        tokens[tokens.Count - 1] += "\r\n" + line;
                    }
                }
                int x = tokens.Count;
            }
        }
    }
