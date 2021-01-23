    public ActionResult Register(string returnUrl)
    {
       ...
       ViewBag.Error = TempData["RoleErrors"] as string;
       return View();
    }
