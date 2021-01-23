    using System;
    using System.Collections;
    using System.Data;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Text;
     
    public class XMLValidator
    {
        // Validation Error Count
        static int ErrorsCount = 0;
     
         // Validation Error Message
        static string ErrorMessage = "";
     
        public static void ValidationHandler(object sender,
                                             ValidationEventArgs args)
        {
            ErrorMessage = ErrorMessage + args.Message + "\r\n";
            ErrorsCount ++;
        }
     
        public void Validate(string strXMLDoc)
        {
            try
            {
                // Declare local objects
                XmlTextReader         tr   = null;
                XmlSchemaCollection   xsc  = null;
                XmlValidatingReader   vr   = null;
     
                // Text reader object
                tr  = new XmlTextReader(urlpath);
                xsc = new XmlSchemaCollection();
                xsc.Add(null, tr);
     
                // XML validator object
     
                vr = new XmlValidatingReader( strXMLDoc,
                             XmlNodeType.Document, null);
     
                vr.Schemas.Add(xsc);
     
                // Add validation event handler
     
                vr.ValidationType = ValidationType.Schema;
                vr.ValidationEventHandler +=
                         new ValidationEventHandler(ValidationHandler);
     
                // Validate XML data
     
                while(vr.Read());
     
                vr.Close();
     
                // Raise exception, if XML validation fails
                if (ErrorsCount > 0)
                {
                    throw new Exception(ErrorMessage);
                }
     
                // XML Validation succeeded
                Console.WriteLine("XML validation succeeded.\r\n");
            }
            catch(Exception error)
            {
                // XML Validation failed
                Console.WriteLine("XML validation failed." + "\r\n" +
                "Error Message: " + error.Message);
            }
        }
    }
