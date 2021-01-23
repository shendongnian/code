    public class ReCaptchaClass
    {
    	private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    	private static string SecretKey = System.Configuration.ConfigurationManager.AppSettings["Google.ReCaptcha.Secret"];
    	[JsonProperty("success")]
    	public bool Success { get; set; }
    	[JsonProperty("error-codes")]
    	public List<string> ErrorCodes { get; set; }
    
    	public static async Task<bool> Validate(HttpRequestBase Request)
    	{
    		string encodedResponse = Request.Form["g-Recaptcha-Response"];			
    		string remoteIp = Request.UserHostAddress;			
    		using (var client = new HttpClient())
    		{
    			var values = new Dictionary<string, string>
    			{
    			   {"secret", SecretKey},
    			   {"remoteIp", remoteIp},
    			   {"response", encodedResponse}
    			};
    			var content = new FormUrlEncodedContent(values);
    			var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
    			var responseString = await response.Content.ReadAsStringAsync();
    			var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass>(responseString);
    			if ((captchaResponse.ErrorCodes?.Count ?? 0) != 0)
    			{
    				log.Warn("ReCaptcha errors: " + string.Join("\n", captchaResponse.ErrorCodes));
    			}
    			return captchaResponse.Success;
    		}
    	}		
    }
