    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            // pretend this is the funThatReturnsXML return value
            var returnedXml = "<tagB><tagBB></tagBB></tagB>";
            // get the outer XML element name
            var xmlElementToRemove = GetOuterXmlElement(returnedXml);
            // load XML from where ever
            var xelement = XElement.Load("XmlDoc.txt");
            // remove the outer element and all subsequent elements
            xelement.Elements().Where(e => e.Name == xmlElementToRemove).Remove();
        }
    
        static string GetOuterXmlElement(string xml)
        {
            var index = xml.IndexOf('>');
            return xml.Substring(1, index - 1);
        }
    }
