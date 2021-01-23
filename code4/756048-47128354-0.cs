    class Program
    {
        static void Main(string[] args)
        {
            var soap = @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/""><s:Body><GetData xmlns = ""http://tempuri.org/""><value>2</value></GetData></s:Body></s:Envelope>";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://localhost:51148/Service1.svc");
            
            req.Headers.Add($"SOAPAction", "http://tempuri.org/IService1/GetData");
            req.ContentType = "text/xml;charset=\"utf-8\"";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(soap);
            req.ContentLength = data.Length;
            req.Accept = "text/xml";
            req.Method = "POST";
            Stream stm = req.GetRequestStream();
            stm.Write(data, 0, data.Length);
            try
            {
                WebResponse response = req.GetResponse();
                Stream responseStream = response.GetResponseStream();
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }
        }
    }
