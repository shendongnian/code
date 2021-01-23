    Controller:
    public ActionResult Login()
    {
        return View("Login");
    }
    [HttpPost]
    public JsonResult Login(string txtUsername, string txtPassword)
    {
        string result = "test result";
        return Json(result);
    }
