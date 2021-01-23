    public void SendMessage(XmlDocument doc)
        {
            var httpWReq = (HttpWebRequest)WebRequest.Create(_extranetRemitService);
            httpWReq.Proxy = WebRequest.GetSystemWebProxy();
            httpWReq.Proxy.Credentials = CredentialCache.DefaultCredentials;
            httpWReq.UseDefaultCredentials = true;
            // encode xml file contents (melFileContents is a string)
            var melMessage = doc.InnerXml;
            byte[] data = Encoding.ASCII.GetBytes(melMessage);
            //post the xml data as text/xml content type
            httpWReq.Method = "POST";
            httpWReq.ContentType = "text/xml;charset=utf-8";
            httpWReq.ReadWriteTimeout = 10000;
            httpWReq.KeepAlive = false;
            httpWReq.ContentLength = data.Length;
            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            var response = (HttpWebResponse)httpWReq.GetResponse();
            response.Close();
        }
