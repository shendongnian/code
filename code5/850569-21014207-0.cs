    public ActionResult Index()
    {
        var profiler = MiniProfiler.Current;
        using (profiler.Step("action"))
        {
            return View();
        }
    }
