    public ActionResult Index()
    {
        ViewBag.Message = "Test webservices";
        if (Request.IsAjaxRequest())
        { getconfig(); }
        return View();
    }
