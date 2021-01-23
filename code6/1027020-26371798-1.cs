    public ActionResult Create()
    {
      MyViewModel model = new MyViewModel();
      model.UserList = new SelectList(db.Users, "UsersId", "Surname");
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(MyViewModel model)
    {
      ...
    }
