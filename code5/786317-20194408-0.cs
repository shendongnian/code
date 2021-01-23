    public static string PostMessage(string body)
    {
           NameValueCollection parameters = new NameValueCollection();
           parameters.Add("body", body);
           string response = string.Empty;
           response = Post("https://www.yammer.com/api/v1/messages/", parameters);
           return response;
    }
    
    public static string Post(string url, NameValueCollection parameters)
    {
                string nonce, timestamp;
                string fullUrl = EncodeUrl(url, parameters);
                string signature = GetSignature(WebMethod.POST, fullUrl, out timestamp, out nonce);
                HttpWebRequest request = CreateWebRequest(url, WebMethod.POST, nonce, timestamp, signature);
    int count = 0;
                string queryString = string.Empty;
                foreach (string key in parameters.Keys)
                {
                    if (count == 0)
                        queryString = key + "=" + Rfc3986.Encode(parameters[key]);
                    else
                        queryString += "&" + key + "=" + Rfc3986.Encode(parameters[key]);
                    count++;
                }
    
                
                byte[] postDataBytes = Encoding.ASCII.GetBytes(queryString);
                request.ContentLength = postDataBytes.Length;
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(postDataBytes, 0, postDataBytes.Length);
                reqStream.Close();
    
    	        WebResponse response = null;
                string data = string.Empty;
                try
                {
                    response = request.GetResponse();
                    data = response.Headers["Location"];
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show("Error retrieving web response " + ex.Message);
                    throw ex;
                }
                finally
                {
                    if (response != null)
                        response.Close();
                }
                return data;
            }
    
            private static string EncodeUrl(string url, NameValueCollection parameters)
            {
                string fullUrl = string.Empty;
                int count = 0;
                foreach (string key in parameters.Keys)
                {
                    if (count == 0)
                        fullUrl = url + "?" + key + "=" + Rfc3986.Encode(parameters[key].ToLower());
                    else
                        fullUrl += "&" + key + "=" + Rfc3986.Encode(parameters[key].ToLower());
                    count++;
                }
                return fullUrl;
            }
    
    
    public static string GetSignature(WebMethod method, string url, out string timestamp, out string nonce)
            {
                OAuthBase oAuth = new OAuthBase();
                nonce = oAuth.GenerateNonce();
                timestamp = oAuth.GenerateTimeStamp();
                string nurl, nrp;
    
                Uri uri = new Uri(url);
                string sig = oAuth.GenerateSignature(
                    uri,
                    YOURCONSUMERKEY,
                    YOURCONSUMER_SECRET,
                    AuthToken,
                    AuthTokenSecret,
                    method.ToString(),
                    timestamp,
                    nonce,
                    OAuthBase.SignatureTypes.PLAINTEXT, out nurl, out nrp);
    
                return System.Web.HttpUtility.UrlEncode(sig);
            }
    
    private static HttpWebRequest CreateWebRequest(string fullUrl, WebMethod method, string nonce, string timeStamp, string sig)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl);
                request.Method = method.ToString();
                request.Proxy = Yammer.Session.WebProxy;
                string authHeader = CreateAuthHeader(method, nonce, timeStamp, sig);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Authorization", authHeader);
                return request;
            }
    
    private static string CreateAuthHeader(WebMethod method, string nonce, string timeStamp, string sig)
    {
                var sb = new StringBuilder();
                sb.Append("OAuth ");
                if (method == WebMethod.POST)
                    sb.Append("realm=\"" + "\",");
                else
                    sb.Append("realm=\"\",");
    
                string authHeader = "oauth_consumer_key=\"" + YOURCONSUMERKEY + "\"," +
                                    "oauth_token=\"" + YOURAUTHTOKEN  + "\"," +
                                    "oauth_nonce=\"" + nonce + "\"," +
                                    "oauth_timestamp=\"" + timeStamp + "\"," +
                                    "oauth_signature_method=\"" + "HMAC-SHA1" + "\"," +
                                    "oauth_version=\"" + "1.0" + "\"," +
                                    "oauth_signature=\"" + sig + "\"";
    
                sb.Append(authHeader);
                return sb.ToString();
    }
