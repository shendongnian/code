	public string[] HtmlDoubleDecode(string[] values)
	{
		return values
			.Select (v => WebUtility.HtmlDecode(WebUtility.HtmlDecode(v)))
			.ToArray();
	}
