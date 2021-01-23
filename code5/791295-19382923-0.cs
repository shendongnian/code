    protected override ViewResult View(string viewName, string masterName, object model)
    {
        foreach (var engine in ViewEngineCollection.OfType<VirtualPathProviderViewEngine>())
        {
            var newLocations = engine.FileExtensions.Select(ext => "~/Views/Foo/{1}/{0}." + ext).ToList();
            newLocations.AddRange(engine.ViewLocationFormats);
            engine.ViewLocationFormats = newLocations.ToArray();
        }
        return base.View(viewName, masterName, model);
    }
