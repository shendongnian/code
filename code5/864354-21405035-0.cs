    void xmlwriter(List<string> message, List<string> time, List<string> test)
        {
        XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(@"E:\\log.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Tests");
            string[] arrayMessage = message.ToArray();
            string[] arrayTime = time.ToArray();
            string[] arrayTest = test.ToArray();
            for (int i = 0; i < arrayMessage.Length; i++)
            {
                writer.WriteStartElement("Test");
                writer.WriteAttributeString("Test", arrayMessage[i]);
                writer.WriteElementString("DateAndTime", arrayTime[i]);
                writer.WriteElementString("Result", arrayTest[i]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }
