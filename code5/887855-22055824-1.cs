    using System;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            var map = new Map();
            Console.WriteLine(map[300000011]);
        }
    }
    
    public class Map: Dictionary<int, string>
    {
        public Map()
        {
            WebClient wc = new WebClient()
            {
                Proxy = null
            };
            
            string rawData = wc.DownloadString("<insert url with data in new format here>");
            PopulateWith(rawData);
        }
        
        void PopulateWith(string rawText)
        {
            string pattern = @"ID: (?<id>\d*) NAME: (?<name>.*)";
            foreach (Match match in Regex.Matches(rawText, pattern)) 
            {
                // TODO: add error handling here
                int id = int.Parse( match.Groups["id"].Value );
                string name = match.Groups["name"].Value;
                
                this[id] = name;
            }
        }    
    }
