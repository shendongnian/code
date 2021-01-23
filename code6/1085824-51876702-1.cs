          public String LinkedINAuth(string code, string state)
                {
                    string authUrl = "https://www.linkedin.com/oauth/v2/accessToken";
        
                    var sign1 = "grant_type=authorization_code&code=" + code + "&redirect_uri=" + redirectUrl + "&client_id=" + apiKey + "&client_secret=" + apiSecret + "&state=" + state;
                    var sign = "grant_type=authorization_code&code=" + HttpUtility.UrlEncode(code) + "&redirect_uri=" + HttpUtility.HtmlEncode(redirectUrl) + "&client_id=" + apiKey + "&client_secret=" + apiSecret + "&state=" + state;
        
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                         | SecurityProtocolType.Tls11
                                                         | SecurityProtocolType.Tls12;
        
                    HttpWebRequest webRequest = System.Net.WebRequest.Create(authUrl + "?" + sign1) as HttpWebRequest;
                    webRequest.Method = "POST";
                    webRequest.Host = "www.linkedin.com";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
        
                    Stream dataStream = webRequest.GetRequestStream();
        
                    String postData = String.Empty;
                    byte[] postArray = Encoding.ASCII.GetBytes(postData);
        
                    dataStream.Write(postArray, 0, postArray.Length);
                    dataStream.Close();
        
                    WebResponse response = webRequest.GetResponse();
                    dataStream = response.GetResponseStream();
        
        
                    StreamReader responseReader = new StreamReader(dataStream);
                    String returnVal = responseReader.ReadToEnd().ToString();
                    responseReader.Close();
                    dataStream.Close();
                    response.Close();
                    var stri = redirectUrl;
                    retval = returnVal.ToString();
                    var objects = JsonConvert.DeserializeObject<Accountdsdsd>(retval);
                    TokenGlobe = objects.access_token;
                    var SentStatus = PostLinkedInNetworkUpdate(TokenGlobe, "Hello API");
                    return TokenGlobe;
        
                }
      public bool PostLinkedInNetworkUpdate(string accessToken, string title, string submittedUrl = defaultUrl, string submittedImageUrl = defaultImageUrl)
            {
                var requestUrl = String.Format(linkedinSharesEndPoint, accessToken);
                var message = new
                {
                    comment = "Testing out the LinkedIn Share API with JSON",
                    content = new Dictionary<string, string>
        {   { "title", title },
            { "description", description},
            { "submitted-url", submittedUrl },
            {"submitted-image-url" , submittedImageUrl}
        },
                    visibility = new
                    {
                        code = "anyone"
                    }
                };
    
                var requestJson = new JavaScriptSerializer().Serialize(message);
    
                var client = new WebClient();
                var requestHeaders = new NameValueCollection
    {
    
        {"Content-Type", "application/json" },
                {"x-li-format", "json" }
    
    };
                client.Headers.Add(requestHeaders);
                var responseJson = client.UploadString(requestUrl, "POST", requestJson);
                var response = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(responseJson);
                return response.ContainsKey("updateKey");
            }
             public class Accountdsdsd
        {
            public string access_token { get; set; }
            public string expires_in { get; set; }
        }
        }
        
    }
