            var config = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings,
                DtdProcessing = DtdProcessing.Ignore,
                ConformanceLevel = ConformanceLevel.Document
            };
            config.ValidationEventHandler += ConfigOnValidationEventHandler;
            config.Schemas = schemas;
