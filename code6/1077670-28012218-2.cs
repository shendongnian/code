    [HttpGet]
    public ActionResult Index()
    {
      ViewBag.UserName = this.User.Identity.Name;
      return View("Index");
    }
