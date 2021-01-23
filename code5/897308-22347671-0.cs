    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace TextNodeChange
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = @"<Info><title>a</title><content>texttexttexttexttext<tag>TAGNAME</tag>texttexttex‌​ttexttext</content>texttexttexttexttext</Info>";
    
                XDocument doc = XDocument.Parse(input);
                Console.WriteLine("Input document");
                Console.WriteLine(doc);
    
                //get the all of the text nodes in the content element
                var textNodes = doc.Element("Info").Element("content").Nodes().OfType<XText>().ToList();
    
                //update the second text node
                textNodes[1].Value = "THIS IS AN ALTERED VALUE!!!!";
    
                Console.WriteLine();
                Console.WriteLine("Output document");
                Console.WriteLine(doc);
                Console.ReadLine();
            }
        }
    }
