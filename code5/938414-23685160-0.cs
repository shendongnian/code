        public class GoogleAuthorizationData
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string token_type { get; set; }
    
        }
    
      public class GoogleUserInfo
        {
            public string name { get; set; }
            public string family_name { get; set; }
            public string gender { get; set; }
            public string email { get; set; }
            public string given_name { get; set; }
            public string picture { get; set; }
            public string link { get; set; }
            public string id { get; set; }
    
        }
    
      Webpage1.aspx
      ============
     protected void Page_Load(object sender, EventArgs e)
            {
                string code = Request.QueryString["code"].ToString();
                string scope = Request.QueryString["scope"].ToString();
                string url = "https://accounts.google.com/o/oauth2/token";
                string postString = "code=" + code + "&client_id=" + ConfigurationManager.AppSettings["GoogleClientID"].ToString() + "&client_secret=" + ConfigurationManager.AppSettings["GoogleSecretKey"].ToString() + "&redirect_uri=" + ConfigurationManager.AppSettings["ResponseUrl"].ToString() + "&grant_type=authorization_code";
    
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
    
                UTF8Encoding utfenc = new UTF8Encoding();
                byte[] bytes = utfenc.GetBytes(postString);
                Stream os = null;
                try
                {
                    request.ContentLength = bytes.Length;
                    os = request.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                }
                catch
                { }
    
                try
                {
                    HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = webResponse.GetResponseStream();
                    StreamReader responseStreamReader = new StreamReader(responseStream);
                    var result = responseStreamReader.ReadToEnd();//
                    var json = new JavaScriptSerializer();
    
                    GoogleAuthorizationData authData = json.Deserialize<GoogleAuthorizationData>(result);
    
                    HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/oauth2/v2/userinfo");
                    request1.Method = "GET";
                    request1.ContentLength = 0;
                    request1.Headers.Add("Authorization", string.Format("{0} {1}", authData.token_type, authData.access_token));
                    HttpWebResponse webResponse1 = (HttpWebResponse)request1.GetResponse();
                    Stream responseStream1 = webResponse1.GetResponseStream();
                    StreamReader responseStreamReader1 = new StreamReader(responseStream1);
                    GoogleUserInfo userinfo = json.Deserialize<GoogleUserInfo>(responseStreamReader1.ReadToEnd());
                   Response.Write(userinfo.email);
    
                }
                catch (Exception eX)
                {
                    throw eX;
                }
    
    
    
    
    
            }
 
