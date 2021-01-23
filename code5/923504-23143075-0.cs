    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            string s = File.ReadAllText(@"D:\Data.txt");
            var matches = Regex.Matches(s, "(?<=start-student)((?!end-student).)*");
            foreach(var m in matches)
            {
                Console.Out.WriteLine(m);
            }
        }
    }
