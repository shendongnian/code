    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("CAT", "Kitty");
            dict.Add("MOUSE", "Jerry");
            var lines = File.ReadAllText("input.txt");
            var regex = new Regex(@"(?<=^=\[?(?:\w*.){3})\w*(?=\..*$)",
                RegexOptions.Multiline |
                RegexOptions.Compiled);
            var result = regex.Replace(lines, m =>
                dict.ContainsKey(m.Value) ? dict[m.Value] : m.Value);
            Console.WriteLine(result);
        }
    }
