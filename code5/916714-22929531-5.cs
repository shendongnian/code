    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    
    class XPathValidation
    {
        static void Main() {
            try {
                // Load the schema string into a memory stream
                string xsdText = "some xml schema string";
                MemoryStream xsd = new MemoryStream(Encoding.ASCII.GetBytes(xsdText));
    
                // create a schema using that memory stream
                ValidationEventHandler eventHandler = new ValidationEventHandler(Validation);
                XmlSchema schema = XmlSchema.Read(xsd, eventHandler);
    
                // create some settings using that schema
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(schema);
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
    
                // Load the xml string into a memory stream
                string xmlText = "some xml string";
                MemoryStream xml = new MemoryStream(Encoding.ASCII.GetBytes(xmlText));
    
                // create a XML reader
                XmlReader reader = XmlReader.Create(xml, settings);
    
                // load the XML into a document
                XmlDocument document = new XmlDocument();
                document.Load(reader);
    
                // validate the XML
                document.Validate(eventHandler);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    
        static void Validation(object sender, ValidationEventArgs e) {
            switch (e.Severity) {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }
    }
