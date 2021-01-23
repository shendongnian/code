        string samlResponseXml = '<SAML Response Message>'
        XmlDocument loginResponseXmlDocument = new XmlDocument();
        loginResponseXmlDocument.LoadXml(samlResponseXml);
        // Add name spaces
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(loginResponseXmlDocument.NameTable);
            namespaceManager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");
            namespaceManager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            namespaceManager.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
            namespaceManager.AddNamespace("xenc", "http://www.w3.org/2001/04/xmlenc#");
        Encrypt(loginResponseXmlDocument, namespaceManager);
        private void Encrypt(XmlDocument document, XmlNamespaceManager namespaceManager)
        {
            // create symmetric key
            var key = new RijndaelManaged();
            key.BlockSize = 128;
            key.KeySize = 256;
            key.Padding = PaddingMode.ISO10126;
            key.Mode = CipherMode.CBC;
            XmlElement assertion = (XmlElement)document.SelectSingleNode("/samlp:Response/saml:Assertion", namespaceManager);
            EncryptedXml eXml = new EncryptedXml();
            byte[] encryptedElement = eXml.EncryptData(assertion, key, false);
            EncryptedData edElement = new EncryptedData
            {
                Type = EncryptedXml.XmlEncAES256Url
            };
            const string encryptionMethod = EncryptedXml.XmlEncAES256Url;
            edElement.EncryptionMethod = new EncryptionMethod(encryptionMethod);
            edElement.CipherData.CipherValue = encryptedElement;
            // edElement = EncryptedData 
            // Now encrypt symmetric key
            string certificateDn = ConfigurationManager.AppSettings["CertificateDN"];
            X509Certificate2 x509Certificate = GetCertificate(certificateDn);
            RSACryptoServiceProvider rsa = x509Certificate.PublicKey.Key as RSACryptoServiceProvider;
            byte[] cryptedData = rsa.Encrypt(key.Key, false);
            //string data = Convert.ToBase64String(cryptedData);
            //byte[] encryptedKey = EncryptedXml.EncryptKey(key.Key, rsa, true);
            EncryptedKey ek = new EncryptedKey();
            ek.CipherData = new CipherData(cryptedData);
            ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);
            //EncryptedData edkey = new EncryptedData(); 
            //string data1 = Convert.ToBase64String(encryptedKey);
            //edkey.CipherData.CipherValue = System.Text.Encoding.Unicode.GetBytes(data);
            rsa.Clear();
            XmlDocument encryptedAssertion = new XmlDocument();
            // Add name spaces
            XmlDeclaration xmlDeclaration = encryptedAssertion.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement encryptedRoot = encryptedAssertion.DocumentElement;
            encryptedAssertion.InsertBefore(xmlDeclaration, encryptedRoot);
            XmlElement encryptedAssertionElement = encryptedAssertion.CreateElement("saml", "EncryptedAssertion", "urn:oasis:names:tc:SAML:2.0:assertion");
            encryptedAssertion.AppendChild(encryptedAssertionElement);
            string xml = edElement.GetXml().OuterXml;
            XmlElement element = AddPrefix(xml, "xenc", "http://www.w3.org/2001/04/xmlenc#");
            var encryptedDataNode = encryptedAssertion.ImportNode(element, true);
            encryptedAssertionElement.AppendChild(encryptedDataNode);
            xml = ek.GetXml().OuterXml;
            element = AddPrefix(xml, "xenc", "http://www.w3.org/2001/04/xmlenc#");
            var encryptedKeyNode = encryptedAssertion.ImportNode(element, true);
            encryptedAssertionElement.AppendChild(encryptedKeyNode);
            var root = document.DocumentElement;
            var node = root.OwnerDocument.ImportNode(encryptedAssertionElement, true);
            root.RemoveChild(assertion);
            root.AppendChild(node);
        }
