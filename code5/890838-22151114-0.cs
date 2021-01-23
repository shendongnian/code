    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new HtmlDocument();
            string tableTag = "<th><a href=\"Boot_53.html\">135 Boot</a></th>";
            doc.LoadHtml(tableTag);
    
            var anchor = doc.DocumentNode.SelectSingleNode("//a");
            if (anchor != null)
            {
                string link = anchor.Attributes["href"].Value;
                Console.WriteLine(link);
            }
        }
    }
