    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        xml.Serialize(writer, Data);
        // I am not 100% sure if this can be optimized
        httpContextBase.Response.BinaryWrite(stream.ToArray());
    }
