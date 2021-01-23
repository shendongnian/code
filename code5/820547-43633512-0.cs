    /// <summary>
    /// Helper method to render views/partial views to strings.
    /// </summary>
    /// <param name="context">The controller</param>
    /// <param name="viewName">The name of the view belonging to the controller</param>
    /// <param name="model">The model which is to be passed to the view, if needed.</param>
    /// <returns>A view/partial view rendered as a string.</returns>
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
