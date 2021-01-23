    [HttpGet]
    public ActionResult RegisterUser()
    {
        if( TempData.ContainsKey( "MessageResult" )
        {
            ViewData["MessageResult"] = TempData["MessageResult"];
            ViewData["cssClass"] = messageResult.cssClass;
        }
        return View(new User());
    }
