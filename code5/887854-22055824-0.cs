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
        readonly Regex _regex = new Regex(@"ID: (?<id>\d*) NAME: (?<name>.*)", RegexOptions.Compiled);
        
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
            foreach (Match match in _regex.Matches(rawText)) 
            {
                // TODO: add error handling here
                int id = int.Parse( match.Groups["id"].Value );
                string name = match.Groups["name"].Value;
                
                this[id] = name;
            }
        }    
    }
