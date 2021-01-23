    public static string RenderViewToString(ControllerContext context, string viewName, object model)
	{
		if (string.IsNullOrEmpty(viewName))
			viewName = context.RouteData.GetRequiredString("action");
		var viewData = new ViewDataDictionary(model);
		using (var sw = new StringWriter())
		{
			var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
			var viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
			viewResult.View.Render(viewContext, sw);
			return sw.GetStringBuilder().ToString();
		}
	}
