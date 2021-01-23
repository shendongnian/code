    HttpGet]
    public ActionResult Index()
    {
      YourViewModel model = new YourViewModel();
      ConfigureViewModel(model);
      return View(model);
    }
    [HtppPost]
    public ActionResult Index(YourViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // Save and redirect
    }
    private void ConfigureViewModel(YourViewModel model)
    {
      using (var db = new BidManagementContext())
      {
        var users = from u in db.LOGIN select u.EmpName;
        ViewBag.AllUsers = new SelectList(users.ToList());
        // or better, model.AllUsers = new SelectList(users.ToList());
      }
      // any other common operations
    }
