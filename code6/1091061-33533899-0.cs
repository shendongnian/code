	public String get_Cookie(String cookieName)
	{
		HTTPRequest Request = System.Web.HttpContext.Current.Request;
		if (Request.Cookies.Get(cookieName) != null)
		{
		    return HttpUtility.UrlDecode(Request.Cookies.Get(cookieName).Value);
		}
		else
		{
		    return String.Empty;
		}
	}
