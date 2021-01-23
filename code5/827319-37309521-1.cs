    XmlWriterSettings xws = new XmlWriterSettings { OmitXmlDeclaration = true };
    using (StreamWriter sw = new StreamWriter(xmlFile))
	using (FileStream fs = new FileStream(jsonFile, FileMode.Open, FileAccess.Read))
    using (StreamReader sr = new StreamReader(fs))
    using (JsonTextReader reader = new JsonTextReader(sr))
    {
        //sw.Write("<root>");
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        JObject obj = JObject.Load(reader);
                        XmlDocument doc = JsonConvert.DeserializeXmlNode(obj.ToString(), "Order");
                        sw.Write(doc.InnerXml); // a line of XML code <Order>...</Order>
                        sw.Write("\n");
                        //this approach produces not strictly valid XML document
                        //add root element at the beginning and at the end to make it valid XML                                
                    }
                }
            }
        }
        //sw.Write("</root>");
    }
