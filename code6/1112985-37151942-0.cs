    public ActionResult Index()
    {
        var DataContext = new EditProfileFormFieldsDataContext();
        return View("EditProfile", DataContext.Controls.ToList());
    }
