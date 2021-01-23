    public ActionResult Index()
    {
        ViewBag.Message = "Test webservices";
        if (Request.IsAjaxRequest())
        { 
            getconfig(); 
            return PartialView("Partial_TotalCount");
        }
        return View();
    }
