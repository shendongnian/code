                XmlDocument xmlDoc = new XmlDocument();
                System.IO.Stream xmlStream;
                System.Xml.Xsl.XslCompiledTransform xsl = new System.Xml.Xsl.XslCompiledTransform();
                ASCIIEncoding enc = new ASCIIEncoding();
                System.IO.StringWriter writer = new System.IO.StringWriter();
            String TransactionXML = "<xml><node></node></xml>";
            // Get Xsl
            xsl.Load(HttpContext.Current.Server.MapPath("footballers.xslt"));
            // Remove the utf encoding as it causes problems with the XPathDocument
            TransactionXML = TransactionXML.Replace("utf-32", "");
            TransactionXML = TransactionXML.Replace("utf-16", "");
            TransactionXML = TransactionXML.Replace("utf-8", "");
            xmlDoc.LoadXml(TransactionXML);
            // Get the bytes
            xmlStream = new System.IO.MemoryStream(enc.GetBytes(xmlDoc.OuterXml), true);
            // Load Xpath document
            System.Xml.XPath.XPathDocument xp = new System.Xml.XPath.XPathDocument(xmlStream);
            // Perform Transform
            xsl.Transform(xp, null, writer);
            Response.Write(writer.ToString());
