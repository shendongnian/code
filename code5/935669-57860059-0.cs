       static class Http
    {
        public static String Post(string uri, NameValueCollection pairs)
        {
            byte[] response = null;
            using (WebClient client = new WebClient())
            {
                response = client.UploadValues(uri, pairs);
            }
            string ret = Encoding.UTF8.GetString(response);
            ret = ret.Trim(new char[] { '\uFEFF', '\u200B' });//removes the BOM 
            return ret;
        }
    }
