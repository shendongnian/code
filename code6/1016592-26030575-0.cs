            public static FacebookRequestData GetInviteHash()
            {
                string requestId = Request["request_ids"];
                var accessToken = GetAccessToken(ConfigurationManager.AppSettings["FacebookAppId"], ConfigurationManager.AppSettings["FacebookSecret"]);
    
                string response;
                using (var webClient = new WebClient())
                {
                    response = webClient.DownloadString(string.Format("https://graph.facebook.com/{0}?{1}", requestId, accessToken));
                }
    
                var javaScriptSerializer = new JavaScriptSerializer();
    
                return javaScriptSerializer.Deserialize<FacebookRequestData>(javaScriptSerializer.Deserialize<FacebookRequestInfo>(response).data);
            }
    
            private static string GetAccessToken(string appId, string password)
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadString(string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&grant_type=client_credentials", appId, password));
                }
            }
    
            private class FacebookRequestInfo
            {
                public string data { get; set; }
            }
