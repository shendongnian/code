    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    public class Program
    {
        public static void Main(string[] args)
        {
            var doc = XDocument.Load("http://classify.oclc.org/classify2/Classify?stdnbr=9780754073963");
            var reader = doc.CreateReader();
            XmlNameTable nameTable = reader.NameTable;
            var nsManager = new XmlNamespaceManager(nameTable);
            nsManager.AddNamespace("c", "http://classify.oclc.org");
            var work = doc.XPathSelectElement("//c:work", nsManager);
            Console.WriteLine(work.Attribute("title").Value);
            var mostPopular = doc.XPathSelectElement("//c:ddc/c:mostPopular", nsManager);
            Console.WriteLine(mostPopular.Attribute("nsfa").Value);            
        }
    }
