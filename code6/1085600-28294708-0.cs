    public static bool Validate(string sFileXML, string sFileXSD)
    {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add(null, sFileXSD);
        settings.ValidationType = ValidationType.Schema;
        XmlDocument document = new XmlDocument();
        document.Load(sFileXML);
        XmlReader objReader = XmlReader.Create(new StringReader(document.InnerXml), settings);
        bool success = true;
        while (objReader.Read()) 
        {
           try{ }
           catch (Exception eException)
           {
                success = false;
                Console.WriteLine(eException.Message);
           }
        }
        return success;
    }
