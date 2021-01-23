    public ActionResult Index()
    {
        var task = DownloadAndSaveFileAsync();
        var model = GetModel();
        await task;
        return View(model);
    }
