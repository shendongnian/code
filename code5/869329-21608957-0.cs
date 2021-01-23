    private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:v1=""http://WSSTestServiceLib/WSSTestOutboundService/V1"">
                <soapenv:Header/>
                <soapenv:Body>
                    <v1:getGreeting/>
                </soapenv:Body>
                </soapenv:Envelope>");
 
            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
 
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    MessageBox.Show(soapResult);
                }
            }
        }
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public HttpWebRequest CreateWebRequest()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://www.XXXXX.com/TestSecurity/V1");
            webRequest.Headers.Add(@"SOAP:Action:""http://WSSTestServiceLib/WSSTestOutboundService/V1/getGreeting");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
 
 
            string certificateName = "name of certificate";
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
            foreach (X509Certificate certificate in certificates)
            {
                webRequest.ClientCertificates.Add(certificate); 
            }
            certificateName = "name of certificate";
            certificates = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
            foreach (X509Certificate certificate in certificates)
            {
                webRequest.ClientCertificates.Add(certificate);
            }
            return webRequest;
        }
