      using Newtonsoft.Json;
        public class ReCaptchaClass
        {
            public static string Validate(string EncodedResponse)
            {
                var client = new System.Net.WebClient();
    
                string PrivateKey = "6LcH-v8SerfgAPlLLffghrITSL9xM7XLrz8aeory";
    
                var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));
    
                var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);
    
                return captchaResponse.Success.ToLower();
            }
    
            [JsonProperty("success")]
            public string Success
            {
                get { return m_Success; }
                set { m_Success = value; }
            }
    
            private string m_Success;
            [JsonProperty("error-codes")]
            public List<string> ErrorCodes
            {
                get { return m_ErrorCodes; }
                set { m_ErrorCodes = value; }
            }
    
    
            private List<string> m_ErrorCodes;
        }
