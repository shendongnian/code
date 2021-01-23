    string xmlResult = string.Empty;
    var xmlSerializer = new XmlSerializer(typeof(car));
    using (var stringWriter = new StringWriter())
    {
        using (var xmlWriter = XmlWriter.Create(stringWriter))
        {
            xmlSerializer.Serialize(xmlWriter, car);
        }
        xmlResult = stringWriter.ToString();
    }
    // save xmlResult to DB
