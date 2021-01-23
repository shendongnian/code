	public bool TryGetValueFromCookie<T>(string cookieName, ref T value)
	{
		HttpCookie cookie = null;
		if (Request.Cookies.AllKeys.Any(key => key.Equals(cookieName)))
		{
			cookie = Request.Cookies.Get(cookieName);
		}
		if (cookie == null || String.IsNullOrEmpty(cookie.Value))
		{
			return false;
		}
		var javaScriptSerializer = new JavaScriptSerializer();
		value = javaScriptSerializer.Deserialize<T>(cookie.Value);
		return true;
	}
	public void SetValueToCookie<T>(string name, T value, DateTime expires)
	{
		var javaScriptSerializer = new JavaScriptSerializer();
		var cookie = new HttpCookie(name) { Value = javaScriptSerializer.Serialize(value), Expires = expires };
		Request.Cookies.Set(cookie);
	}
