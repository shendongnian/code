    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    using System.IO;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                string original = File.ReadAllText("Demo.html");
    
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(original);
    
                var nodes = doc.DocumentNode.SelectNodes("//img[@class='instagramimage']");
                foreach (var node in nodes)
                {
                    Console.WriteLine(node.GetAttributeValue("src","not available"));
                }
    
    
    
            }
        }
    }
