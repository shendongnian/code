      public class TwitterHelper
    {
        public const string OauthVersion = "1.0";
        public const string OauthSignatureMethod = "HMAC-SHA1";
 
        public TwitterHelper(string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret)
        {
            this.ConsumerKey = consumerKey;
            this.ConsumerKeySecret = consumerKeySecret;
            this.AccessToken = accessToken;
            this.AccessTokenSecret = accessTokenSecret;
        }
 
        public string ConsumerKey { set; get; }
        public string ConsumerKeySecret { set; get; }
        public string AccessToken { set; get; }
        public string AccessTokenSecret { set; get; }
         
        public string GetTweets(string twitterHashTag, int count)
        {
            string resourceUrl = string.Format("https://api.twitter.com/1.1/search/tweets.json");
            var requestParameters = new SortedDictionary<string, string>();
            requestParameters.Add("q", twitterHashTag);
            requestParameters.Add("count", count.ToString());
            requestParameters.Add("result_type", "mixed");
            var response = GetResponse(resourceUrl, "GET", requestParameters);
            return response;
        }
  
        private string GetResponse(string resourceUrl, string methodName, SortedDictionary<string, string> requestParameters)
        {
            ServicePointManager.Expect100Continue = false;
            WebRequest request = null;
            string resultString = string.Empty;
             
            request = (HttpWebRequest)WebRequest.Create(resourceUrl + "?" + requestParameters.ToWebString());
            request.Method = methodName;
            request.ContentType = "application/x-www-form-urlencoded";
             
             
            if (request != null)
            {
                var authHeader = CreateHeader(resourceUrl, methodName, requestParameters);
                request.Headers.Add("Authorization", authHeader);
 
                var response = (HttpWebResponse)request.GetResponse();
                using (var sd = new StreamReader(response.GetResponseStream()))
                {
                    resultString = sd.ReadToEnd();
                    response.Close();
                }
            }
            return resultString;
        }
 
        private string CreateOauthNonce()
        {
            return Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        }
 
        private string CreateHeader(string resourceUrl, string methodName, SortedDictionary<string, string> requestParameters)
        {
            var oauthNonce = CreateOauthNonce();
            // Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString())); 
            var oauthTimestamp = CreateOAuthTimestamp();
            var oauthSignature = CreateOauthSignature(resourceUrl, methodName, oauthNonce, oauthTimestamp, requestParameters);
            //The oAuth signature is then used to generate the Authentication header. 
            const string headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " + "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " + "oauth_token=\"{4}\", oauth_signature=\"{5}\", " + "oauth_version=\"{6}\"";
            var authHeader = string.Format(headerFormat, Uri.EscapeDataString(oauthNonce), Uri.EscapeDataString(OauthSignatureMethod), Uri.EscapeDataString(oauthTimestamp), Uri.EscapeDataString(ConsumerKey), Uri.EscapeDataString(AccessToken), Uri.EscapeDataString(oauthSignature), Uri.EscapeDataString(OauthVersion));
            return authHeader;
        }
        private string CreateOauthSignature(string resourceUrl, string method, string oauthNonce, string oauthTimestamp, SortedDictionary<string, string> requestParameters)
        {
            //firstly we need to add the standard oauth parameters to the sorted list 
            requestParameters.Add("oauth_consumer_key", ConsumerKey);
            requestParameters.Add("oauth_nonce", oauthNonce);
            requestParameters.Add("oauth_signature_method", OauthSignatureMethod);
            requestParameters.Add("oauth_timestamp", oauthTimestamp);
            requestParameters.Add("oauth_token", AccessToken);
            requestParameters.Add("oauth_version", OauthVersion);
            var sigBaseString = requestParameters.ToWebString();
            var signatureBaseString = string.Concat(method, "&", Uri.EscapeDataString(resourceUrl), "&", Uri.EscapeDataString(sigBaseString.ToString()));
             
            var compositeKey = string.Concat(Uri.EscapeDataString(ConsumerKeySecret), "&", Uri.EscapeDataString(AccessTokenSecret));
            string oauthSignature;
            using (var hasher = new HMACSHA1(Encoding.ASCII.GetBytes(compositeKey)))
            {
                oauthSignature = Convert.ToBase64String(hasher.ComputeHash(Encoding.ASCII.GetBytes(signatureBaseString)));
            }
            return oauthSignature;
        }
        private static string CreateOAuthTimestamp()
        {
            var nowUtc = DateTime.UtcNow;
            var timeSpan = nowUtc - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString(); return timestamp;
        }
    }
 
    public static class Extensions
    {
        public static string ToWebString(this SortedDictionary<string, string> source)
        {
            var body = new StringBuilder();
            foreach (var requestParameter in source)
            {
                body.Append(requestParameter.Key);
                body.Append("=");
                body.Append(Uri.EscapeDataString(requestParameter.Value));
                body.Append("&");
            } //remove trailing '&' 
            body.Remove(body.Length - 1, 1); return body.ToString();
        }
    }
    
