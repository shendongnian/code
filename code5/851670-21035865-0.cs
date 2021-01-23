    [OutputCache(
        NoStore = HttpContext.Current.IsDebuggingEnabled, 
        Duration=(HttpContext.Current.IsDebuggingEnabled)?0:15
    )]
    public ActionResult RenderSomething(int somethingID)
    {
    ...
    }
