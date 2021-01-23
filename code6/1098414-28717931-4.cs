    using System;
    using System.Linq;
    using System.Xml.Linq;
    					
    public class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load("test.xml");
            XNamespace ns = "http://2013-02-01/";
            XNamespace kw = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace aw = "http://data.schemas";
            var query = doc.Descendants(aw + "Data")
                    .Where(x => (string)x.Attribute(kw + "type") == "green")
                    .Elements(ns + "Document")
                    .Elements(ns + "Country")
                    .Select(x => x.Value);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
