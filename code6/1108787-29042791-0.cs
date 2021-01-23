    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var request = new XDocument();
    
            using (var writer = request.CreateWriter())
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("CUSTOMER");
                writer.WriteElementString("ADDRESS", "123 Fake St.");
                writer.WriteElementString("CITY", "San Jose");
                writer.WriteElementString("STATE", "CA");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
    
            // XDocument.ToString() will print:
            //<CUSTOMER>
            //  <ADDRESS>123 Fake St.</ADDRESS>
            //  <CITY>San Jose</CITY>
            //  <STATE>CA</STATE>
            //</CUSTOMER>
            Console.WriteLine(request.ToString());
    
            // And here's how to use the XmlWriterSettings with XDocument.Save:
            var writerSettings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8
            };
    
            using (var writer = XmlWriter.Create("test.xml", writerSettings))
            {
                request.Save(writer);
            }
    
            // The above will write (you could adjust the XmlWriterSettings to add whitespace):
            //<CUSTOMER><ADDRESS>123 Fake St.</ADDRESS><CITY>San Jose</CITY><STATE>CA</STATE></CUSTOMER>
        }
    }
