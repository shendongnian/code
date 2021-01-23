    public ActionResult Index() {
        ViewBag.UserIP = Request.UserHostAddress;
        if (Request.UserHostAddress != "192.168.0.5")
            throw new HttpException((int)System.Net.HttpStatusCode.Forbidden, "Accès non autorisé");
        return View();
    }
