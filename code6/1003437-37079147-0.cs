    public partial class twitter_followers : System.Web.UI.Page
    {
        public string strTwiterFollowers { get; set; }
        private List<TwiterFollowers> listFollowers = new List<TwiterFollowers>();
        private bool useScreenName = false;
        private string screen_name = string.Empty;
        // oauth application keys
        private string oauth_consumer_key = string.Empty;
        private string oauth_consumer_secret = string.Empty;
        // oauth implementation details
        private string oauth_version = "1.0";
        private string resource_urlFormat = "https://api.twitter.com/1.1/followers/list.json?screen_name={0}&cursor={1}";
        // unique request details
        private string oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        protected void Page_Load(object sender, EventArgs e)
        {
            bool.TryParse(ConfigurationManager.AppSettings[GetVariableName(() => useScreenName)], out useScreenName);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[GetVariableName(() => screen_name)])) {
                screen_name = ConfigurationManager.AppSettings[GetVariableName(() => screen_name)];
            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[GetVariableName(() => oauth_consumer_key)]))
            {
                oauth_consumer_key = ConfigurationManager.AppSettings[GetVariableName(() => oauth_consumer_key)];
            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[GetVariableName(() => oauth_consumer_secret)]))
            {
                oauth_consumer_secret = ConfigurationManager.AppSettings[GetVariableName(() => oauth_consumer_secret)];
            }
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[GetVariableName(() => oauth_version)]))
            {
                oauth_version = ConfigurationManager.AppSettings[GetVariableName(() => oauth_version)];
            }
            var resource_url = "https://api.twitter.com/1.1/followers/list.json";
            if (useScreenName & !string.IsNullOrEmpty(screen_name))
            {
                resource_url += string.Concat("?screen_name=", screen_name);
            }
            StartCreateCall(string.Empty);
        }
        private void StartCreateCall(string cursor) {
            // You need to set your own keys and screen name
            var oAuthUrl = "https://api.twitter.com/oauth2/token";
            // Do the Authenticate
            var authHeaderFormat = "Basic {0}";
            var authHeader = string.Format(authHeaderFormat,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oauth_consumer_key) + ":" +
                Uri.EscapeDataString((oauth_consumer_secret)))
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
                using (var reader = new StreamReader(authResponse.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objectText = reader.ReadToEnd();
                    twitAuthResponse = JsonConvert.DeserializeObject<TwitAuthenticateResponse>(objectText);
                }
            }
            CallData(twitAuthResponse, authHeader, cursor);
            int totalFollowers = listFollowers.Count;
            lblTotalFollowers.Text = screen_name + " has " + listFollowers.Count + " Followers";
            Random objRnd = new Random();
            List<TwiterFollowers> randomFollowers = listFollowers.OrderBy(item => objRnd.Next()).ToList<TwiterFollowers>();
            foreach (TwiterFollowers tw in randomFollowers)
            {
                strTwiterFollowers = strTwiterFollowers + "<li><a target='_blank' title='" + tw.ScreenName + "' href=https://twitter.com/" + tw.ScreenName + "><img src='" + tw.ProfileImage + "'/><span>" + tw.ScreenName + "</span></a></li>";
            }
        }
        private void CallData(TwitAuthenticateResponse twitAuthResponse, string authHeader, string cursor)
        {
            try {
                JObject j = GetJSonObject(twitAuthResponse, authHeader, cursor);
                JArray data = (JArray)j["users"];
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        TwiterFollowers objTwiterFollowers = new TwiterFollowers();
                        objTwiterFollowers.ScreenName = item["screen_name"].ToString().Replace("\"", "");
                        objTwiterFollowers.ProfileImage = item["profile_image_url"].ToString().Replace("\"", "");
                        objTwiterFollowers.UserId = item["id"].ToString().Replace("\"", "");
                        listFollowers.Add(objTwiterFollowers);
                    }
                    JValue next_cursor = (JValue)j["next_cursor"];
                    if (long.Parse(next_cursor.Value.ToString()) > 0)
                    {
                        CallData(twitAuthResponse, authHeader, next_cursor.Value.ToString());
                    }
                }
            } catch (Exception ex)
            {
                //do nothing
            }
        }
        private JObject GetJSonObject(TwitAuthenticateResponse twitAuthResponse, string authHeader, string cursor)
        {
            string resource_url = string.Format(resource_urlFormat, screen_name, cursor);
            if (string.IsNullOrEmpty(cursor))
            {
                resource_url = resource_url.Substring(0, resource_url.IndexOf("&cursor"));
            }
            HttpWebRequest fRequest = (HttpWebRequest)WebRequest.Create(resource_url);
            var timelineHeaderFormat = "{0} {1}";
            fRequest.Headers.Add("Authorization", string.Format(timelineHeaderFormat, twitAuthResponse.token_type, twitAuthResponse.access_token));
            fRequest.Method = "Get";
            WebResponse response = fRequest.GetResponse();
            string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JObject.Parse(result);
        }
        private string GetVariableName<T>(Expression<Func<T>> expr)
        {
            var body = (MemberExpression)expr.Body;
            return body.Member.Name;
        }
        private class TwitAuthenticateResponse
        {
            public string token_type { get; set; }
            public string access_token { get; set; }
        }
        private class TwiterFollowers
        {
            public string ScreenName { get; set; }
            public string ProfileImage { get; set; }
            public string UserId { get; set; }
        }
    }
