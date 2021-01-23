	public static class HtmlExtensions
	{
		public static IHtmlString RegisteredRawScripts(this HtmlHelper htmlHelper)
		{
			var ctx = htmlHelper.ViewContext.HttpContext;
			var registeredScripts = ctx.Items["_rawscripts_"] as Stack<string>;
			if (registeredScripts == null || registeredScripts.Count < 1)
			{
				return null;
			}
			var sb = new StringBuilder();
			foreach (var script in registeredScripts)
			{
				sb.AppendLine("\r\n" + script);
			}
			return new HtmlString(sb.ToString());
		}
		public static void RegisterRawScript(this HtmlHelper htmlHelper, string script)
		{
			var ctx = htmlHelper.ViewContext.HttpContext;
			var registeredScripts = ctx.Items["_rawscripts_"] as Stack<string>;
			if (registeredScripts == null)
			{
				registeredScripts = new Stack<string>();
				ctx.Items["_rawscripts_"] = registeredScripts;
			}
			if (!registeredScripts.Contains(script))
			{
				registeredScripts.Push(script);
			}
		}
	}
