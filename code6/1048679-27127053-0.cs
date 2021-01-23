    public string ToXml()
    {
        return ToXml(typeof(TContent).Name);
    }
    public string ToXml(string contentElementName)
    {
        XmlElementAttribute element = new XmlElementAttribute(contentElementName, typeof(TContent));
        XmlAttributes attributes = new XmlAttributes();
        attributes.XmlElements.Add(element);
        XmlAttributeOverrides overrides = new XmlAttributeOverrides();
        overrides.Add(typeof(Envelope<TContent>), "Content", attributes);
        return ToXml(this, overrides);
    }
    public string ToXml(Envelope<TContent> value, XmlAttributeOverrides overrides) 
    {
        using (var sw = new Utf8StringWriter())
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = omitXmlDeclaration,
                Indent = true
            };
            XmlSerializer xs = new XmlSerializer(typeof(Envelope<TContent>), overrides);
            using (XmlWriter writer = XmlWriter.Create(sw, settings))
            {
                xs.Serialize(writer, value);
            }
            return sw.ToString();
        }
    }
