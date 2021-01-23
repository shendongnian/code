        using (MemoryStream stream = new MemoryStream())
        {
            using (XmlWriter writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.WriteRaw("<int>123</int>");
                writer.Flush();
            }
            stream.Seek(0, SeekOrigin.Begin);
            using (XmlReader reader = new XmlTextReader(stream))
            {
                SqlXml sqlXml = new SqlXml(reader);
                int value = GetInt32(sqlXml);
                Debug.Assert(123 == value);
            }
        }
