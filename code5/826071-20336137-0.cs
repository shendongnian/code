    public static HtmlString MyHelper(this HtmlHelper html)
    {
        var controllerContext = html.ViewContext.Controller.ControllerContext;
        var result = ViewEngines.Engines.FindView(controllerContext, name, null);
        ...
    }
