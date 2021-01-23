    [HttpGet]
    public ActionResult Authenticate()
    {
        var model = new AuthViewModel { MyId = 123 };
        return View("Index", model );
    }
