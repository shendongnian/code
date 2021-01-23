    var htmlContent = string.Empty;
    var view = ViewEngines.Engines.FindView(ControllerContext, relativePath, null);
    using (var writer = new StringWriter())
    {
        var context = new ViewContext(ControllerContext, view.View, ViewData, TempData, writer);
        view.View.Render(context, writer);
        writer.Flush();
        htmlContent = writer.ToString();
    }
