    Stream s;
    // XML is in this stream
    command.Parameters.Add(new SqlParameter("@xmlParameterName", SqlDbType.Xml)
    {
        Value = new SqlXml(XmlReader.Create(s));
    });
