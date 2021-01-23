    [AllowAnonymous]
            public ActionResult Register()
            {
                ViewBag.Registration = "x";//x or whatever
                return View();
            }
    
    @if (!String.IsNullorEmpty(ViewBag.Registration))
            {
            <legend>Register using another service.</legend>
            }
            else
            {
            <legend>Use another service to log in.</legend>
            }
