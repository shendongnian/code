    public ActionResult Index()
    {
        NewLogin newLogin = PopUserDDL();
        return View(newLogin);
    }
