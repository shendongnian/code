    public override void OnActionExecuted(ActionExecutedContext context) {
        var pageFactory = (IRazorPageFactory)context.HttpContext.ApplicationServices.GetService(typeof(IRazorPageFactory));
        var viewEngine = (IRazorViewEngine)context.HttpContext.ApplicationServices.GetService(typeof(IRazorViewEngine));
        var viewFactory = (IRazorViewFactory)context.HttpContext.ApplicationServices.GetService(typeof(IRazorViewFactory));
        var sb = new StringBuilder();
        var sw = new StringWriter(sb);
        var page = pageFactory.CreateInstance($"~/Areas/Widgets/DefaultViews/Widgets/{widgetInfo.Type}.cshtml");
        var view = (RazorView)viewFactory.GetView(viewEngine, page, true);
        var vddType = typeof(ViewDataDictionary<>);
        var vddGeneric = vddType.MakeGenericType(widgetInfo.Model.GetType());
        dynamic viewDataDictionary = Activator.CreateInstance(vddGeneric, new EmptyModelMetadataProvider(), new ModelStateDictionary());
        var actionContext = new ActionContext(context.HttpContext, context.RouteData, context.ActionDescriptor);
        var viewContext = new ViewContext(actionContext, view, viewDataDictionary, sw);
        viewContext.ViewData.Model = widgetInfo.Model;
        view.RenderAsync(viewContext).GetAwaiter().GetResult();
        sw.Flush();
        var renderedWidget = sb.ToString();
    }
