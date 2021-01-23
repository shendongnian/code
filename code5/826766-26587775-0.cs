        #region properties
        private Boolean errorValidate;
        #endregion
        public void Main(String xmlValidate)
        {
            errorValidate = false;
            //Load the XmlSchemaSet.
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "..\\..\\Schemas\\ED.xsd");
            //Validate the file using the schema stored in the schema set. 
            //Any elements belonging to the namespace "urn:cd-schema" generate
            //a warning because there is no schema matching that namespace.
            Validate(xmlValidate, schemaSet);
            Console.ReadLine();
        }
        private void Validate(String filename, XmlSchemaSet schemaSet)
        {
            Console.WriteLine();
            Console.WriteLine("\r\nValidating XML file {0}...", filename.ToString());
            XmlSchema compiledSchema = null;
            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                compiledSchema = schema;
            }
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(compiledSchema);
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            settings.ValidationType = ValidationType.Schema;
            //Create the schema validating reader.
            XmlReader vreader = XmlReader.Create(filename, settings);
            while (vreader.Read()) { }
            //Close the reader.
            vreader.Close();
            if (errorValidate)
            {
                Console.WriteLine("\r\nWarning or Error was found in validation process on XML file {0}", filename.ToString());
            }
            else
            {
                Console.WriteLine("\r\nValidated XML file {0}", filename.ToString());
            }
        }
        //Display any warnings or errors. 
        private void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            errorValidate = true;
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            else
                Console.WriteLine("\tValidation error: " + args.Message);
        }
    }
