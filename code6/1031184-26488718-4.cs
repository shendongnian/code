    public ActionResult Index()
    {
        FormViewModel newForm = new FormViewModel() { Item3 = true; } //This will mark it as checked
        return View(newForm);
    }
