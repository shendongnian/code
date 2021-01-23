    public ActionResult Index()
    { 
        if (null == TheCache.Instance.GetCache("key"))
            TheCache.Instance.SetCache("key", "value", DateTime.Now.AddHours(1));
        return View();
    }
