    public static bool ValidateXml(string schemaFilePath, string xmlFilePath)
        {
            bool isValidXml = false;
            try
            {
                var ds = new DataSet();
                ds.ReadXmlSchema(schemaFilePath);
                ds.ReadXml(xmlFilePath);
                isValidXml = true;
            }
            catch (Exception ex)
            {
                isValidXml = false;
            }
            return isValidXml;
        }
