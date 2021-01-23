    /// Encodes to MvcHtmlString and includes HTML tags or already encoded strings, placeholder is the '|' character
	public static MvcHtmlString FormatWithHtml (this string format, params string[] htmlIncludes) 
    {
		var result = new StringBuilder();
		int i = -1;
		foreach(string part in format.Split('|')) {
			result.Append(HttpUtility.HtmlEncode(part));
			if (++i < htmlIncludes.Length)
				result.Append(htmlIncludes[i]);
		}
		return new MvcHtmlString(result.ToString());
	}
