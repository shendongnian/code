    string output;
    XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
    using (TextWriter writer = new StreamWriter(xml)) <-- StringWriter is Possible here? -->
    {
        serializer.Serialize(writer, XmlData);
        output = writer.ToString();
    } 
