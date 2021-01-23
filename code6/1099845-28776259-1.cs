    public ActionResult Create()
    {
      ItemVM model = new ItemVM();
      // map all purposes from database, for example
      model.Purposes = db.Purposes.Select(p => new PurposeVM()
      {
        Id = p.Id,
        Name = p.Name
      });
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(ItemVM model)
    {
    }
