            // XML File found
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(val);
            string xmlcontents = doc.InnerXml;
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlcontents)))
            {
                reader.ReadToFollowing("recordingowner");
                string t = reader.ReadElementString();
                Console.WriteLine(t);
            }
