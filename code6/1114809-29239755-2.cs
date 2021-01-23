            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
                var ns = new XmlSerializerNamespaces();
                ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    (new XmlSerializer(typeof(CameraPropertyList))).Serialize(xmlWriter, properties, ns);
                xmlOut = textWriter.ToString();
            }
