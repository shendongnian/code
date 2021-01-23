    public HttpPostedFileBase MyFile { get; set; }
    public Stream GetXmlStream()
        {
            using (Stream inputStream = MyFile.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                memoryStream = new MemoryStream();
                inputStream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }
    public class XmlValidator
    {
        public string Error;
        public bool ValidateXml(Stream memoryStream)
        {
            try
            {
                string XsdPath = @"C:\Projects\Mvc\Xsd\books.xsd";
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add("", XsdPath);
                settings.ValidationType = ValidationType.Schema;
                XmlReader reader = XmlReader.Create(memoryStream, settings);
                XmlDocument document = new XmlDocument();
                try
                {
                    document.Load(reader);
                }
                catch (XmlException ex)
                {
                    UploadedFile.Error = String.Format("Line {0}, position {1}: {2}", ex.LineNumber, ex.LinePosition,
                        ex.Message);
                    return false;
                }
                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
                document.Validate(eventHandler);
                reader.Close();
                return true;
            }
            catch (XmlSchemaValidationException ex)
            {
               UploadedFile.Error = String.Format("Line {0}, position {1}: {2}", ex.LineNumber, ex.LinePosition, ex.Message);
            }
            return false;
        }
        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
        }
    }
    
