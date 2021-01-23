    Controller:
    public ActionResult Login()
    {
        return View("Login");
    }
    [HttpPost]
    public JsonResult Login(string name, string pass)
    {
        string result = "test result";
        return Json(result);
    }
