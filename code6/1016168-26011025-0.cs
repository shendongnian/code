    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace XSLCreator
    {
       class Program
       {
          static void Main(string[] args)
          {
             XNamespace xsl = XNamespace.Get("http://www.w3.org/1999/XSL/Transform");
    
             var doc = new XDocument(
                 new XElement(xsl + "stylesheet",
                     new XAttribute(XNamespace.Xmlns + "xsl", xsl),
                     new XAttribute("version", "1.0")
                 )
             );
    
             var sw = new StreamWriter("test.xml");
             XmlWriter xw = new  XmlTextWriter(sw);
             doc.WriteTo(xw);
             xw.Close();
             sw.Close();
          }
       }
    }
