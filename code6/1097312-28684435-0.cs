    protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
            String authInfo = Convert.ToBase64String(Encoding.Default.GetBytes("username:password"));
            request.Headers["Authorization"] = "Basic " + authInfo;
            return request;
        }
