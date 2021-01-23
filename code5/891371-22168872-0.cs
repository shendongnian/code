        public static bool Validate(XmlSchemaSimpleTypeRestriction restriction, string value)
        {
            var schema = new XmlSchema();
            schema.Items.Add(new XmlSchemaElement
            {
                Name = "value",
                SchemaType = new XmlSchemaSimpleType { Content = restriction }
            });
            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(schema);
            var readerSettings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings,
                Schemas = schemaSet
            };
            string xml = new XElement("value", value).ToString();
            try
            {
                var reader = XmlReader.Create(new StringReader(xml), readerSettings);
                while (reader.Read()) ;
                return true;
            }
            catch (XmlSchemaValidationException)
            {
                return false;
            }
        }
