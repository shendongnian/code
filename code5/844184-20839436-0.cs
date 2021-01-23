    public sealed class CookieHelper
    {
    private HttpRequestBase _request;
    private HttpResponseBase _response;
    public CookieHelper(HttpRequestBase request, 
	HttpResponseBase response)
	{
		_request = request;
		_response = response;
	}
    //[DebuggerStepThrough()]
    public void SetLoginCookie(string userName,string password,bool isPermanentCookie)
    {
        if (_response != null)
        {
            if (isPermanentCookie)
            {
                FormsAuthenticationTicket userAuthTicket = 
                	new FormsAuthenticationTicket(1, userName, DateTime.Now, 
                	DateTime.MaxValue, true, password,               FormsAuthentication.FormsCookiePath);
                string encUserAuthTicket = FormsAuthentication.Encrypt(userAuthTicket);
                HttpCookie userAuthCookie = new HttpCookie
                	(FormsAuthentication.FormsCookieName, encUserAuthTicket);
                if (userAuthTicket.IsPersistent) userAuthCookie.Expires = 
						userAuthTicket.Expiration;
                userAuthCookie.Path = FormsAuthentication.FormsCookiePath;
                _response.Cookies.Add(userAuthCookie);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(userName, isPermanentCookie);
            }
        }
    }
    }
