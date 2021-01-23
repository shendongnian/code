    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ProhibitDtd = false;
    settings.ValidationType = ValidationType.DTD;
    
    using (XmlReader reader = XmlReader.Create(@"file.xml", settings))
    {
        try
        {
            while (reader.Read()) { }
        }
        catch (XmlException e)
        {
            Console.WriteLine(e.Message);
        }
    }
