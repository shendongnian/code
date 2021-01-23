            string avatarUri = "https://wb01.miracast.com/Primary/services/requestlist/getrequestlist?id=80FC46F4&queryby=requestid&format=xml";
            HttpWebRequest request =
                (HttpWebRequest)HttpWebRequest.Create(avatarUri);
            request.Method = "GET";        // Post method
            X509Certificate cert = X509Certificate.CreateFromCertFile(@"C:\Users\kim\Desktop\oas-test.cer");
            request.ClientCertificates.Add(cert);
            // Attaching the Certificate To the request
            System.Net.ServicePointManager.CertificatePolicy =
                                   new TrustAllCertificatePolicy();
            request.UseDefaultCredentials = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            HttpWebResponse wResp = (HttpWebResponse)request.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding(1252);
            StreamReader loResponseStream = new
              StreamReader(wResp.GetResponseStream(), enc);
            string Response = loResponseStream.ReadToEnd();
            loResponseStream.Close();
            wResp.Close();
