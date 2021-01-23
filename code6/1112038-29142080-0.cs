    string xml = "<Region Region_Sequence=\"1\" Region_Name=\"Vadodra\" Region_Code=\"VAD\"/>"
    
    var serializer = new XmlSerializer(typeof(Region));
    Region result;
    
    using (TextReader reader = new StringReader(xml))
    {
        result = (Region)serializer.Deserialize(reader);
    }
