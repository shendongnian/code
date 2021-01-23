    // You need to set your own keys and screen name
    var oAuthConsumerKey = "superSecretKey";
    var oAuthConsumerSecret = "superSecretSecret";
    var oAuthUrl = "https://api.twitter.com/oauth2/token";
    var screenname = "aScreenName";
    
    // Do the Authenticate
    var authHeaderFormat = "Basic {0}";
    
    var authHeader = string.Format(authHeaderFormat,
        Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oAuthConsumerKey) + ":" +
        Uri.EscapeDataString((oAuthConsumerSecret)))
    ));
    
    var postBody = "grant_type=client_credentials";
    
    HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
    authRequest.Headers.Add("Authorization", authHeader);
    authRequest.Method = "POST";
    authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
    authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    
    using (Stream stream = authRequest.GetRequestStream())
    {
        byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
        stream.Write(content, 0, content.Length);
    }
    
    authRequest.Headers.Add("Accept-Encoding", "gzip");
    
    WebResponse authResponse = authRequest.GetResponse();
    // deserialize into an object
    TwitAuthenticateResponse twitAuthResponse;
    using (authResponse)
    {
        using (var reader = new StreamReader(authResponse.GetResponseStream())) {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var objectText = reader.ReadToEnd();
            twitAuthResponse = JsonConvert.DeserializeObject<TwitAuthenticateResponse>(objectText);
        }
    }
