            string xml = @"<Camera_Properties>
                <Property Name=""Height"" Value=""40"" Category=""Dimensions"" Type=""Int"" Description=""The height of the box""/>
                <Property Name=""Width"" Value=""40"" Category=""Dimensions"" Type=""Int"" Description=""The width of the box""/>
            </Camera_Properties>
            ";
            CameraPropertyList properties;
            using (StringReader reader = new StringReader(xml))
            {
                properties = (CameraPropertyList)(new XmlSerializer(typeof(CameraPropertyList))).Deserialize(reader);
            }
            string xmlOut;
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    (new XmlSerializer(typeof(CameraPropertyList))).Serialize(xmlWriter, properties);
                xmlOut = textWriter.ToString();
            }
            Debug.WriteLine(xmlOut);
