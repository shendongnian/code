    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main(string[] args)
        {
            var xml = XDocument.Load("test.xml", LoadOptions.SetLineInfo);
            var xpath = "/root/child";
            var result = xml.XPathSelectElements(xpath);
            foreach (var element in result)
            {
                var info = (IXmlLineInfo) element;
                Console.WriteLine("{0}:{1} {2}",
                                  info.LineNumber,
                                  info.LinePosition,
                                  element);
            }
        }
    }
