    public static void PatchEncoding(string xmlPath,  XDocument xmlDoc, string encoding = "windows-1251")
    {
            using (var stream = new MemoryStream())
            using (XmlTextWriter xmlwriter = new XmlTextWriter(stream, Encoding.GetEncoding(encoding)))
            {
                xmlDoc.Save(xmlPath);
            }
    }
            
