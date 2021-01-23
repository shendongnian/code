    public static MvcHtmlString Highlight<T>(this HtmlHelper htmlHelper, string fieldName, SearchResult<T> fromResult) where T : class
	{
		var value = fromResult.Document.GetType().GetProperty(fieldName).GetValue(fromResult.Document, null) as string;
		if (fromResult.Highlights == null || !fromResult.Highlights.ContainsKey(fieldName))
		{
			return MvcHtmlString.Create(htmlHelper.Encode(value));
		}
		var highlights = fromResult.Highlights[fieldName];
		var hits = highlights
			.Select(h => h.Replace("<b>", string.Empty).Replace("</b>", string.Empty))
			.ToList();
		for (int i = 0; i < highlights.Count; i++)
		{
			value = value.Replace(hits[i], highlights[i]);
		}
		return MvcHtmlString.Create(htmlHelper.Encode(value).Replace("&lt;b&gt;", "<b>").Replace("&lt;/b&gt;", "</b>"));
	}
