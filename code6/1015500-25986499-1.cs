    public ActionResult Create(int? id)
    {
      ServiceHistory model = new ServiceHistory();
      model.AssetID = id;
      return View(model);
    }
