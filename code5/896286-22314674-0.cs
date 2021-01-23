    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            string[] locations = 
            { 
                "110 - Main Road", 
                "123 - Highway", 
                "234 - My House", 
                "1120 - Main Road" 
            };
            Regex r = new Regex(@"^\d+");
            foreach (string location in locations)
            {
                Console.WriteLine(location.Substring(0, location.IndexOf(' ')));
                Console.WriteLine(r.Match(location).Captures[0].Value);
            }
        }
    }
