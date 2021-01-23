    private static void ValidationCallBack(object sender, ValidationEventArgs args)
    {
        response.IsXMLValid = false;
        if (args.Severity == XmlSeverityType.Warning)
        {
            XMLValidationMessage xmlm = new XMLValidationMessage();
            xmlm.Severity = XmlSeverityType.Warning;
            xmlm.LineNumber = 0;
            xmlm.LinePosition = 0;
            xmlm.Message = "Matching schema not found.  No validation occurred.";
            response.ValidationErrors.Add(xmlm);
        }
        else
        {
            // this will give you the name of the schema element that failed validation 
            var schemaInfo = ((XmlReader)sender).SchemaInfo;
            var elementThatFailedValidation = schemaInfo.SchemaElement.Name;
            XMLValidationMessage xmlm = new XMLValidationMessage();
            xmlm.Severity = XmlSeverityType.Error;
            xmlm.LineNumber = args.Exception.LineNumber;
            xmlm.LinePosition = args.Exception.LinePosition;
            xmlm.Message = args.Message;
            response.ValidationErrors.Add(xmlm);
        }
    }
