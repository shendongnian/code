    [HttpPost]
    // [ValidateAntiForgeryToken]
    [ValidateInput(false)]
    public ActionResult Index(RegTeg.Models.ApplicationName appName)
    {
        ... existing code here ...
    }
