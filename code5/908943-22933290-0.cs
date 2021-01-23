    public class SAMLProcessor
    {
        #region Properties
        public string DecodedSAML { get; set; }
        public string EncodedeSAML { get; set; }
        public string Audience { get; set; }
        public string SubjectNameID { get; set; }
        public string FirstName { get; set; }
        public string Mail { get; set; }
        public string LastName { get; set; }
        public bool AuthenticationStatus { get; set; }
        public string Issuer { get; set; }
        public string Destination { get; set; }
        public string ResponseID { get; set; }
        public bool VerifiedResponse { get; set; }
        public string SignatureValue { get; set; }
        public string SignatureReferenceDigestValue { get; set; }
        public DateTime AutheticationTime { get; set; }
        public string AuthenticationSession { get; set; }
        #endregion
        #region Ctror
        public SAMLProcessor(string rawSamlData)
        {
            EncodedeSAML = rawSamlData;
            // the sample data sent us may be already encoded, 
            // which results in double encoding
            if (rawSamlData.Contains('%'))
            {
                rawSamlData = HttpUtility.UrlDecode(rawSamlData);
            }
            // read the base64 encoded bytes
            string samlAssertion = Decode64Bit(rawSamlData);
            DecodedSAML = samlAssertion;
            SamlParser(DecodedSAML);
        }
        #endregion
        private static string Decode64Bit(string rawSamlData)
        {
            byte[] samlData = Convert.FromBase64String(rawSamlData);
            // read back into a UTF string
            string samlAssertion = Encoding.UTF8.GetString(samlData);
            return samlAssertion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="samldata"></param>
        /// <returns></returns>
        public string SamlParser(string samlXMLdata)
        {
            //samldata = Decode64Bit("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4=") + samldata;
            string samldata = samlXMLdata;
            if (!samldata.StartsWith(@"<?xml version="))
            {
                samldata = Decode64Bit("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4=") + samldata;
            }
            string firstName = string.Empty;
            XmlDocument xDoc = new XmlDocument();
            samldata = samldata.Replace(@"\", "");
            xDoc.LoadXml(samldata);
            //xDoc.Load(new System.IO.TextReader());//Suppose the xml you have provided is stored in this xml file.
            XmlNamespaceManager xMan = new XmlNamespaceManager(xDoc.NameTable);
            xMan.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");
            xMan.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            xMan.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
            XmlNode xNode = xDoc.SelectSingleNode("/samlp:Response/samlp:Status/samlp:StatusCode/@Value", xMan);
            if (xNode != null)
            {
                this.AuthenticationStatus = false;
                string statusCode = xNode.Value;
                if (statusCode.EndsWith("status:Success"))
                {
                    this.AuthenticationStatus = true;
                }
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/@Destination", xMan);
            if (xNode != null)
            {
                this.Destination = xNode.Value;
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/@IssueInstant", xMan);
            if (xNode != null)
            {
                this.AutheticationTime = Convert.ToDateTime(xNode.Value);
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/@ID", xMan);
            if (xNode != null)
            {
                this.ResponseID = xNode.Value;
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/saml:Issuer", xMan);
            if (xNode != null)
            {
                this.Issuer = xNode.InnerText;
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/ds:Signature/ds:SignedInfo/ds:Reference/ds:DigestValue", xMan);
            if (xNode != null)
            {
                this.SignatureReferenceDigestValue = xNode.InnerText;
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/ds:Signature/ds:SignatureValue", xMan);
            if (xNode != null)
            {
                this.SignatureValue = xNode.InnerText;
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/saml:Assertion/@ID", xMan);
            if (xNode != null)
            {
                this.AuthenticationSession = xNode.Value;
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:Subject/saml:NameID", xMan);
            if (xNode != null)
            {
                this.SubjectNameID = xNode.InnerText;
            }
            xNode = xDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:Conditions/saml:AudienceRestriction/saml:Audience", xMan);
            if (xNode != null)
            {
                this.Audience = xNode.InnerText;
            }
            //reverse order
            //</saml:AttributeValue></saml:Attribute></saml:AttributeStatement></saml:Assertion></samlp:Response>
            //string xQryStr = "//NewPatient[Name='" + name + "']";
            //XmlNode matchedNode = xDoc.SelectSingleNode(xQryStr);
            // samlp:Response  saml:Assertion saml:AttributeStatement saml:Attribute
            xNode = xDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name = 'FIRSTNAME']/saml:AttributeValue", xMan);
            if (xNode != null)
            {
                this.FirstName = xNode.InnerText;
            }
            // samlp:Response  saml:Assertion saml:AttributeStatement saml:Attribute
            xNode = xDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name = 'MAIL']/saml:AttributeValue", xMan);
            if (xNode != null)
            {
                this.Mail = xNode.InnerText;
            }
            // samlp:Response  saml:Assertion saml:AttributeStatement saml:Attribute
            xNode = xDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name = 'LASTNAME']/saml:AttributeValue", xMan);
            if (xNode != null)
            {
                this.LastName = xNode.InnerText;
            }
            return this.FirstName;
        }
    }
