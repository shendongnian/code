	public static MvcHtmlString ActionMenuItem(
		this HtmlHelper htmlHelper,
		String linkText,
		String actionName,
		String controllerName,
		String iconType = null,
		string classCustom = null,
		params KeyValuePair<string, string>[] subMenus)
	{ ... }
	var dict = new Dictionary<string, string>()
	{
		{ "a", "b" },
		{ "c", "d" },
	};
	
	*.ActionMenuItem(*, *, *, *, *, dict.ToArray());
