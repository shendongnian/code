    public ActionResult Index()
    {
        var value = Session["value"];
        Session["value"] = "foo";
        return View();
    }
    public ActionResult Logout()
    {
        var value = Session["value"];
        Session.Abandon();
        value = Session["value"];
        FormsAuthentication.SignOut();
        return RedirectToAction("Index", "Home");
    } 
