    using DocumentFormat.OpenXml.Validation;
    using System.Diagnostics;
    
    
    public static bool IsDocumentValid(WordprocessingDocument mydoc)
            {
                OpenXmlValidator validator = new OpenXmlValidator();
                var errors = validator.Validate(mydoc);
                Debug.Write(Environment.NewLine);
                foreach (ValidationErrorInfo error in errors)
                    Debug.Write(error.Description + Environment.NewLine);
                return (errors.Count() == 0);
            }
