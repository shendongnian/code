	namespace RecaptchaV2.NET
	{
	  /// <summary>
	  /// Helper Methods for the Google Recaptcha V2 Library
	  /// </summary>
	  public class Recaptcha
	  {
		public string SiteKey { get; set; }
		public string SecretKey { get; set; }
		public Guid SessionId { get; set; }
		/// <summary>
		/// Validates a Recaptcha V2 response.
		/// </summary>
		/// <param name="recaptchaResponse">g-recaptcha-response form response variable (HttpContext.Current.Request.Form["g-recaptcha-response"])</param>
		/// <returns>RecaptchaValidationResult</returns>
		public RecaptchaValidationResult Validate(string recaptchaResponse)
		{
		  RecaptchaValidationResult result = new RecaptchaValidationResult();
		  HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=" + SecretKey + "&response="
			+ recaptchaResponse + "&remoteip=" + GetClientIp());
		  //Google recaptcha Response
		  using (WebResponse wResponse = req.GetResponse())
		  {
			using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
			{
			  string jsonResponse = readStream.ReadToEnd();
			  JavaScriptSerializer js = new JavaScriptSerializer();
			  result = js.Deserialize<RecaptchaValidationResult>(jsonResponse.Replace("error-codes", "ErrorMessages").Replace("success", "Succeeded"));// Deserialize Json
			}
		  }
		  return result;
		}
		private string GetClientIp()
		{
		  // Look for a proxy address first
		  String _ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
		  // If there is no proxy, get the standard remote address
		  if (string.IsNullOrWhiteSpace(_ip) || _ip.ToLower() == "unknown")
			_ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
		  return _ip;
		}
	  }
	  public class RecaptchaValidationResult
	  {
		public RecaptchaValidationResult()
		{
		  ErrorMessages = new List<string>();
		  Succeeded = false;
		}
		public List<string> ErrorMessages { get; set; }
		public bool Succeeded { get; set; }
		public string GetErrorMessagesString()
		{
		  return string.Join("<br/>", ErrorMessages.ToArray());
		}
	  }
	}
