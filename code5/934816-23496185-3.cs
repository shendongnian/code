    private static void ParseXml()
    {
        XDocument doc = XDocument.Load(@"C:\schema.xml");
        if (doc != null)
        {
            XElement nodes = GetComplexType("station", doc);
            if (nodes != null)
            {
                Console.WriteLine("station found...");
            }
            else
            {
                Console.WriteLine("station NOT found!!");
            }
        }
    }
    private static XElement GetComplexType(string typeName, XDocument xsdSchema)
    {
        XNamespace ns = "http://www.w3.org/2001/XMLSchema";
        XElement complexType = xsdSchema.Descendants(ns + "complexType")
            .Where(a => a.Attributes("name").FirstOrDefault() != null && a.Attribute("name").Value == typeName)
            .FirstOrDefault();
        return complexType;
    }
