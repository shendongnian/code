    public static string GetChild(string formatType, string child)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                XDocument doc = XDocument.Load(reader);
                var val = doc.Descendants().Where(a => a.Name.LocalName == "format" && a.FirstAttribute.Value == formatType).Select(a => a.Element(child)).First().Value;
                return val;
            }            
        }
