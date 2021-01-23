        public const string ACCESSKEY = "xxxxx";
        public const string SECRETKEY = "zzzzz";
        public const string TAG = "ccccc";
        private XmlDocument XML;
        public void ProcessRequest(HttpContext context)
        {
            string ts = DateTime.UtcNow.ToString("s");
            string url = "http://webservices.amazon.com/onca/xml?";
            string req = "AWSAccessKeyId=" + ACCESSKEY + "&AssociateTag=" + TAG;
            // Search by ISBN:
            req = req + "&Condition=All&IdType=ISBN&ItemId=0596004923&Operation=ItemLookup&ResponseGroup=Small&SearchIndex=Books&Service=AWSECommerceService";
            string tsq = "&Timestamp=" + URLEncode(ts + "Z").ToUpper();
            
            string s = "GET\nwebservices.amazon.com\n/onca/xml\n" + req + tsq;
            string hash = HashString(s);
            req = req + tsq + "&Signature=" + hash;
            url = url + req;
            ReadXML(url);
            WriteXML();
        }
        private void ReadXML(string url)
        {
            XML = new XmlDocument();
            XML.Load(url);
        }
        private void WriteXML()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.Write(XML.OuterXml);
            HttpContext.Current.Response.End();
        }
        private string UCaseUrlEncode(string s)
        {
            char[] x = HttpUtility.UrlEncode(s).ToCharArray();
            for (int i = 0; i < x.Length - 2; i++)
            {
                if (x[i] == '%')
                {
                    x[i+1] = char.ToUpper(x[i+1]);
                    x[i+2] = char.ToUpper(x[i+2]);
                }
            }
            return new string(x);
        }
        private string URLEncode(string s)
        {
            return(HttpContext.Current.Server.UrlEncode(s));
        }
        private string URLDecode(string s)
        {
            return (HttpContext.Current.Server.UrlDecode(s));
        }
        private string HashString(string s)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(SECRETKEY);
            byte[] messageBytes = encoding.GetBytes(s);
            HMACSHA256 hmasha256 = new HMACSHA256(keyByte);
            byte[] hashmessage = hmasha256.ComputeHash(messageBytes);
            return (UCaseUrlEncode(Convert.ToBase64String(hashmessage)));
        }
        private string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
