    void Main()
    {
    	string eventValidationToken = string.Empty;
    	
    	var firstResponse = this.Get(@"http://localhost:7428/Account/Login");
    	
    	firstResponse.FormValues["ctl00$MainContent$Email"] = "email@example.com";
    	firstResponse.FormValues["ctl00$MainContent$Password"] = "password";
    
    	string secondRequestPostdata = firstResponse.ToString();
    	var secondResponse = this.Post(@"http://localhost:7428/Account/Login", secondRequestPostdata);
    	
    	Console.WriteLine (firstResponse.FormValues["__EVENTVALIDATION"]);
    	Console.WriteLine (secondResponse.FormValues["__EVENTVALIDATION"]);
    }
    
    
    public FormData Get(string uri)
    {
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7428/Account/Login");
    	using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    	using (Stream stream = response.GetResponseStream())
    	using (StreamReader reader = new StreamReader(stream))
    	{
    		return  new FormData(reader.ReadToEnd());
    	}
    }
    
    public FormData Post(string uri, string postContent)
    {
    	byte[] formBytes = Encoding.UTF8.GetBytes(postContent);
    	
    	var request = (HttpWebRequest)WebRequest.Create("http://localhost:7428/Account/Login");
    	request.Method = "POST";
    	request.ContentType = "application/x-www-form-urlencoded";
    	request.ContentLength = formBytes.Length;
    	
    	using (Stream stream = request.GetRequestStream())
    	{
    		stream.Write(formBytes, 0, formBytes.Length);
    	}
    	
    	using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    	using (Stream stream = response.GetResponseStream())
    	using (StreamReader reader = new StreamReader(stream))
    	{
    		return new FormData(reader.ReadToEnd());
    	}
    }
    
    public class FormData
    {
    	public FormData(string html)
    	{
    		this.Html = html;
    	
    		this.FormValues = new Dictionary<string, string>();
    		this.FormValues["__EVENTTARGET"] 				= this.Extract(@"__EVENTTARGET");
    		this.FormValues["__EVENTARGUMENT"] 				= this.Extract(@"__EVENTARGUMENT");
    		this.FormValues["__VIEWSTATE"]					= this.Extract(@"__VIEWSTATE");
    		this.FormValues["__VIEWSTATEGENERATOR"] 		= this.Extract(@"__VIEWSTATEGENERATOR");
    		this.FormValues["__EVENTVALIDATION"] 			= this.Extract(@"__EVENTVALIDATION");
    		this.FormValues["ctl00$MainContent$Email"] 		= string.Empty;
    		this.FormValues["ctl00$MainContent$Password"]	= string.Empty;
    		this.FormValues["ctl00$MainContent$ctl05"] 		= "Log in";
    	}
    	
    	public string Html { get; set; }
    	
    	private string Extract(string id)
    	{
    		return Regex.Match(this.Html, @"id=""" + id + @""" value=""([^""]*)")
    					.Groups[1]
    					.Value;
    	}
    	
    	public Dictionary<string, string> FormValues { get;set; }
    	
    	public override string ToString()
    	{
    		var formData = this.FormValues.Select(form => HttpUtility.UrlEncode(form.Key) + "=" + HttpUtility.UrlEncode(form.Value));
    						
    		return string.Join("&", formData);
    	}
    }
