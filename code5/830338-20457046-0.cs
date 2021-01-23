    public ActionResult Index()
    {
        var model = new EnquiryForm();
        
        ViewBag.PartySizes = Enumearable.Range(1, 8);
        return View(model);
    }
