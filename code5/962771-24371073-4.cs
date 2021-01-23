    var serializetest = new Serializetest();
    string xmlText;
    var serializer = new XmlSerializer(typeof(Serializetest));
    using (var textWriter = new StringWriter())
    {
        using (var xmlWriter = XmlWriter.Create(textWriter))
        {
            serializer.Serialize(xmlWriter, serializetest);
        }
        
        xmlText = textWriter.ToString();
    }
    var doc = new XmlDocument();
    doc.LoadXml(xmlText);
    var jsonText = JsonConvert.SerializeXmlNode(doc);
           
    var json = JObject.Parse(jsonText);
    var empty = (string)json.SelectToken("Serializetest.Empty");
    // This should return empty string instead of null.
