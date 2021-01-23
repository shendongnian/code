    public ActionResult Index(int requestValue)
    {
    	var name = "testCookie";
    	var oldVal = Request.Cookies[name] != null ? Request.Cookies[name].Value : null;
    	var val = (!String.IsNullOrWhiteSpace(oldVal) ? oldVal + ";" : null) + requestValue.ToString();
    
    	var cookie = new HttpCookie(name, val)
    	{
    		HttpOnly = false,
    		Secure = false,
    		Expires = DateTime.Now.AddHours(1)
    	};
    
    	HttpContext.Response.Cookies.Set(cookie);
    
    	return Content("Cookie set.");
    }
