    public ActionResult Create()
    {
      List<RoleDetail> model = new List<RoleDetail>();
      // populate the collection, for example
      foreach(var name in Enum.GetNames(typeof(ControllerName)))
      {
        model.Add(new RoleDetail()
        {
          ControllerName = name,
          IsCreate = true // etc
        });
      }  
      return View(model);
    }
    public ActionResult Create(IEnumerable<RoleDetail> model)
    {
    }
