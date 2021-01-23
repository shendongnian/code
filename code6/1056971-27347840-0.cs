                const string rootNamespace = "urn:oecd:ties:stfatypes:v1";
                const string ftcNamespace = "urn:oecd:ties:a:v1";
                const string xsiNamespace = "http://www.a.com/2001/XMLSchema-instance";
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                };
                var sb = new StringBuilder();
                using (var writer = XmlWriter.Create(sb, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("ftc:A", rootNamespace);
                    writer.WriteAttributeString("xmlns", "", null, rootNamespace);
                    writer.WriteAttributeString("xmlns", "ftc", null, ftcNamespace);
                    writer.WriteAttributeString("xmlns", "xsi", null, xsiNamespace);
                    writer.WriteAttributeString("version", "1.1");
                    writer.WriteAttributeString("schemaLocation", xsiNamespace, "urn:oecd:ties:a:v1 aXML_v1.1.xsd");
                    writer.WriteStartElement("b", ftcNamespace);
                    writer.WriteElementString("z", rootNamespace, "1");
                    writer.WriteElementString("x", rootNamespace, "CO");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
