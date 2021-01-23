    protected override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        if (filterContext.Result is ViewResult)
        {
            foreach (var engine in ViewEngineCollection.OfType<VirtualPathProviderViewEngine>())
            {
                var newViewLocations = engine.FileExtensions.Select(ext => "~/Views/Foo/{1}/{0}." + ext).ToList();
                newViewLocations.AddRange(engine.ViewLocationFormats);
                engine.ViewLocationFormats = newViewLocations.ToArray();
            }
        }
        base.OnResultExecuting(filterContext);
    }
    protected override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        if (filterContext.Result is ViewResult)
        {
            foreach (var engine in ViewEngineCollection.OfType<VirtualPathProviderViewEngine>())
            {
                var removeViewLocations = engine.FileExtensions.Select(ext => "~/Views/Foo/{1}/{0}." + ext).ToList();
                var removedLocations = engine.ViewLocationFormats.ToList();
                removedLocations.RemoveAll(x => removeViewLocations.Contains(x));
                engine.ViewLocationFormats = removedLocations.ToArray();
            }
        }
        base.OnResultExecuted(filterContext);
    }
