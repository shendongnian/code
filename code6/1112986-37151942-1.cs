    public ActionResult Index()
    {
        var DataContext = new EditProfileFormFieldsDataContext();
        return View(DataContext.Controls.ToList());
    }
