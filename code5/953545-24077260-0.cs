    private Audit GetAuditNodes()
    {
        Audit audit = null;
        XmlSerializer serializer = new XmlSerializer(typeof(Audit));
        string uri = "data.xml";
        try
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CheckCharacters = false;
            settings.CloseInput = true;
            settings.DtdProcessing = DtdProcessing.Ignore;
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(uri, settings))
            {
                audit = (Audit)serializer.Deserialize(reader);
            }
        }
        catch (Exception exc)
        {
             //log an error or something
        }
        return audit;
    }
