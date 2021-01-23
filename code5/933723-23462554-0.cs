     public void SetCookie(string name, string value, int expiration)
    {
    	if(Request.Browser.Cookies)
    	{
    		if (Request.Cookies[name] != null)
    		{
    			DeleteCookie(name);
    		}
    		
    		HttpCookie cookie;
    		cookie = new HttpCookie(name);
    		cookie.Value = value;
    		cookie.Expires = DateTime.Now.AddDays(expiration);
    		Response.Cookies.Add(cookie);
    	}
    }
