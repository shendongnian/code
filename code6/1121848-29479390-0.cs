    public class CookieAwareWebClient : WebClient
    {
    	public CookieAwareWebClient()
    	{
    		CookieContainer = new CookieContainer();
    		this.ResponseCookies = new CookieCollection();
    	}
    
    	public CookieContainer CookieContainer { get; private set; }
    	public CookieCollection ResponseCookies { get; set; }
    
    	protected override WebRequest GetWebRequest(Uri address)
    	{
    		var request = (HttpWebRequest)base.GetWebRequest(address);
    		request.CookieContainer = CookieContainer;
    		return request;
    	}
    
    	protected override WebResponse GetWebResponse(WebRequest request)
    	{
    		var response = (HttpWebResponse)base.GetWebResponse(request);
    		this.ResponseCookies = response.Cookies;
    		return response;
    	}
    }
