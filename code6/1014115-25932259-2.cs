    [HttpGet]
    public ActionResult Index(string filtername)
    {
      var filterresults = from m in db.UserInfoes select m;
      filterresults = filterresults.Where(x => x.UserCode.ToString().Contains(filtername)).OrderBy(x => x.UserCode);
      ....
      MasterModel model = new MasterModel();
      model.UserInfo = filterresults;
      // set other properties of model as required
      return View(model);
    }
