	public static class HtmlFilter
	{
		private static HashSet<string> _keep;
		static HtmlFilter()
		{
			_keep = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			_keep.Add("b");
			_keep.Add("em");
			_keep.Add("i");
			_keep.Add("span");
			_keep.Add("strong");
			// Add other tags as needed.
		}
		private static string ElementFilter(Match match)
		{
			string tag = match.Result("${tag}");
			if (_keep.Contains(tag))
				return match.Value;
			else
				return string.Empty;
		}
		public static string Apply(string input)
		{
			Regex regex = new Regex(@"</?(?<tag>\w*)[^>]*>|&nbsp;");
			return regex.Replace(input, new MatchEvaluator(ElementFilter));
		}
	}
