    using System;
    using System.Xml;
    					
    public class Program
    {
        static void Main(string[] args)
        {
            // As per the question
            string myXML = "...";
            string myValue = XMLSelect(myXML, "ns:createTransactionResponse/ns:messages/ns:resultCode");
            Console.WriteLine(myValue);
        }
    
        public static string XMLSelect(string _xmldoc, string _xpath)
        {
            string returnedValue = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(_xmldoc);        
            var nsm = new XmlNamespaceManager(doc.NameTable);
            nsm.AddNamespace("ns", "AnetApi/xml/v1/schema/AnetApiSchema.xsd");
            XmlElement root = doc.DocumentElement;
            return (string)doc.SelectNodes(_xpath, nsm)[0].InnerText;
        }
    }
