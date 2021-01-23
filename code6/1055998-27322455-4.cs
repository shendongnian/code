        public static string ToXml(this DataTable dt)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    ";
                // settings.OmitXmlDeclaration = false; not necessary since this is the default anyway.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    dt.WriteXml(xmlWriter);
                    return textWriter.ToString();
                }
            }
        }
