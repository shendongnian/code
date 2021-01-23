        private const string EndTag = "</RootNode>";
        private void AppendXmlFile()
        {
            using (var fs = File.OpenWrite(XmlFilename))
            {
                fs.Seek(-EndTag.Length, SeekOrigin.End);
                var settings = new XmlWriterSettings {OmitXmlDeclaration = true};
                using (var writer = XmlWriter.Create(fs, settings))
                {
                    writer.WriteStartElement("xyzzy");
                    writer.WriteAttributeString("magic", "plugh");
                    writer.WriteEndElement();
                }
            }
            // Now write the end tag
            File.AppendAllText(XmlFilename, EndTag);
        }
