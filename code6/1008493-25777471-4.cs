    public ActionResult Index()
    {
      MyViewModel model = new MyViewModel();
      model.Data = db.vw_FormattedData.ToList();
      var queryLevels = from a in db.Level select a;
      model.Levels = new SelectList(queryLevels, "id", "levelDescription");
      return View(model);
    }
