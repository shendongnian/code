	private static readonly Regex urlRegEx = new Regex(@"(?<!="")((http|ftp|https|file):\/\/[\d\w\-_]+(\.[\w\-_]+)*([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");
	private static readonly Regex quotedUrlRegEx = new Regex(@"(?<!=)([""']|&quot;|&#39;)((http|ftp|https|file):\/\/[\d\w\-_]+(\.[\w\-_]+)*([\w\-\.,@?^=%&amp;:/~\+# ])*)\1");
	public static MvcHtmlString DisplayWithLinksFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
		Expression<Func<TModel, TProperty>> expression,
		string templateName = null)
	{
		var encodedHTML = htmlHelper.DisplayFor(expression, templateName);
		return MvcHtmlString.Create(ReplaceUrlsWithLinks(encodedHTML.ToHtmlString()));
	}
	private static string ReplaceUrlsWithLinks(string input)
	{
		input = input.Replace(@"\\", @"file://").Replace('\\', '/');
		var result = quotedUrlRegEx.Replace(input, delegate(Match match)
		{
			string url = match.Groups[2].Value;
			return String.Format("<a href=\"{0}\">{1}</a>", Uri.EscapeUriString(url), ShortenURL(url));
		});
		return urlRegEx.Replace(result, delegate(Match match)
		{
			string url = match.ToString();
			return String.Format("<a href=\"{0}\">{1}</a>", Uri.EscapeUriString(url), ShortenURL(url));
		});
	}
	private static string ShortenURL(string url)
	{
		url = url.Substring(url.IndexOf("//", StringComparison.Ordinal) + 2);
		if (url.Length < 60)
			return url;
		var host = url.Substring(0, url.IndexOf("/", StringComparison.Ordinal));
		return host + "/&hellip;";
	}
