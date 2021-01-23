        public static string POST(string url, string requestXML)
        {
            WebRequest webReq = HttpWebRequest.Create(url);
            webReq.ContentType = "application/x-www-form-urlencoded";
            webReq.Method = "POST";
            using (var stream = webReq.GetRequestStream())
            {
                var arrBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(requestXML);
                stream.Write(arrBytes, 0, arrBytes.Length);
                stream.Close();
            }
            WebResponse webResp = webReq.GetResponse();
            var respStream = webResp.GetResponseStream();
            var reader = new StreamReader(respStream, System.Text.Encoding.ASCII);
            string strResponse = reader.ReadToEnd();
            respStream.Close();
            return strResponse;
        }
