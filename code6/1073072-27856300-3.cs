	public static class CookieCollectionExtensions
	{
		public static NameValueCollection ToNameValueCollection(
		      this HttpCookieCollection cookieCollection)
		{
			var nvc = new NameValueCollection();
			foreach (var key in cookieCollection.AllKeys)
			{
				nvc.Add(key, cookieCollection[key].Value);
			}
			
			return nvc;
		}
	}
