    public ActionResult Index()
    {
        if (Session["token"] == null)
        {
            if (Request.QueryString["code"] != null)
            {
                Session["token"] = "tokenValue";
                return View("dummy");
            }
        }
        return View();
    }
