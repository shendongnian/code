        public static bool ValidateXml(string schemaFilePath, string xmlFilePath)
        {
            bool isValidXml = true;
            var doc = XDocument.Load(xmlFilePath);
            var schemas = new XmlSchemaSet();
            const string xn = "http://orlen.pl/xi/prowizja/CODO";
            schemas.Add(xn, XmlReader.Create(schemaFilePath));
            doc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                isValidXml = false;
            });
            Console.WriteLine("doc {0}", isValidXml ? "validated" : "did not validate");
            return isValidXml;
        }
