    public ActionResult Index()
    {
        var model = new CellPhoneCarriersViewModel();
        model.Items = new SelectList(...);
        return View(model);
    }
