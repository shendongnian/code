    public ViewResult Page(string urlSlug)
    {
        if (!this.ViewExists(urlSlug))
        {
            throw new HttpException(404, "Page not found");
        }
            
        return this.View(urlSlug);
    }
    private bool ViewExists(string name)
    {
        ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, name, null);
        return (result.View != null);
    }
