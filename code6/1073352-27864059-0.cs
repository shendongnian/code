    var cookie = Request.Cookies.Get("LoremIpsum");
	if (!string.IsNullOrEmpty(cookie.Value))
	{
		Response.Cookies["LoremIpsum"] = cookie;
	}
