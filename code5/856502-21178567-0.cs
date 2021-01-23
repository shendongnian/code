    public static void Main()
        {
            // Alternate Method for getting the Fields from the XML file
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("C:/Users/Administrator/Downloads/direct.xml");
            XmlNamespaceManager xmlnm = new XmlNamespaceManager(xmlDocument.NameTable);
            xmlnm.AddNamespace("de", "http://www.w3.org/2005/Atom"); 
            **** add this too****
            xmlnm.AddNamespace("m", "http://schemas.giooglt.com/ado/2007/08/dataservices/metadata");
            ParseXML(xmlDocument, xmlnm);
            Console.WriteLine("\n---XML parsed---");
            Console.ReadKey();
        }
   
     public static void ParseXML(XmlDocument xmlFile, XmlNamespaceManager xmlnm)
        {
           /// inline should be ""m"" not ""de""
            XmlNodeList nodes = xmlFile.SelectNodes("//de:entry/de:link/m:inline/de:feed/de:id", xmlnm);
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node.Name + " = " + node.InnerXml);
            }
        }
