	public static CookieContainer DeepClone(CookieContainer src)
	{
		CookieContainer cookieContainer = new CookieContainer();
		Hashtable table = (Hashtable)src.GetType().InvokeMember("m_domainTable", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, src, new object[] { });
		foreach (var tableKey in table.Keys)
		{
			String str_tableKey = (string)tableKey;
			if (str_tableKey[0] == '.')
				str_tableKey = str_tableKey.Substring(1);
			SortedList list = (SortedList)table[tableKey].GetType().InvokeMember("m_list", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, table[tableKey], new object[] { });
			foreach (var listKey in list.Keys)
			{
				String url = "https://" + str_tableKey + (string)listKey;
				CookieCollection collection = src.GetCookies(new Uri(url));
				foreach (Cookie c in collection)
					cookieContainer.Add(new Cookie(c.Name, c.Value, c.Path, c.Domain)
					{
						Comment = c.Comment,
						CommentUri = c.CommentUri,
						Discard = c.Discard,
						Expired = c.Expired,
						Expires = c.Expires,
						HttpOnly = c.HttpOnly,
						Port = c.Port,
						Secure = c.Secure,
						Version = c.Version
					});
			}
		}
		return cookieContainer;
	}
