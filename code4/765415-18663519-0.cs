    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                WebClient wc = new WebClient();
                var sourceCode = wc.DownloadString("http://dota-trade.com/equipment?order=name");
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(sourceCode);
                var node = doc.DocumentNode;
                var nodes = node.SelectNodes("//a");
                List<string> links = new List<string>();
                foreach (var item in nodes)
                {
                    var link = item.Attributes["href"].Value;
                    links.Add(link.Contains("http") ? link : "http://dota-trade.com" +link);
                    Console.WriteLine(link.Contains("http") ? link : "http://dota-trade.com" + link);
                }
                System.IO.File.WriteAllLines(@"C:\Users\Public\WriteLines.txt", links);
            }
        }
    }
`
