    public XElement ToXElement()
    {
        XDocument doc = new XDocument();
        using (XmlWriter xw = doc.CreateWriter())
        {
    
                var xmlSerializer = new XmlSerializer(typeof (T));
                xmlSerializer.Serialize(xw, this);
        }
    
        return doc.Root;
    }
