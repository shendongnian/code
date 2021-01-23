    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    
    namespace ConsoleApplication63
    {
        class Program
        {
            static void Main(string[] args)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load("http://stackoverflow.com/questions/22767900/xpath-search-for-multiple-keywords");
    
                foreach (HtmlTextNode text in doc.DocumentNode.Descendants().OfType<HtmlTextNode>().Where(n => Regex.IsMatch(n.InnerText, @"\b(Frozen|obamacare)\b")))
                {
                    Console.WriteLine("Found \"{0}\"", text.InnerText);
                }
            }
        }
    }
