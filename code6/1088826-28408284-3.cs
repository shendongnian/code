    public ActionResult Index()
    { 
        if (null == TheCache.GetCache("key"))
            TheCache.SetCache("key", "value", DateTime.Now.AddHours(1));
        return View();
    }
