	public static string ToUrlQuery(IEnumerable<KeyValuePair<string, object>> pairs)
	{
		var q = new StringBuilder();
		foreach (var pair in pairs)
			if (pair.Value != null) {
				if (q.Length > 0) q.Append('&');
				q.Append(pair.Key).Append('=').Append(WebUtility.UrlEncode(Convert.ToString(pair.Value, CultureInfo.InvariantCulture)));
			}
		return q.ToString();
	}
