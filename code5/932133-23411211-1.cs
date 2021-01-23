       [AllowAnonymous]
    public ActionResult Register()
    {
        var Vdab = new SelectList(new []{
            new SelectListItem { Value = bool.TrueString, Text = "Ja" },
            new SelectListItem { Value = bool.FalseString, Text = "Nee" }
        });
        ViewBag.Vdab = Vdab;
        return View();
    }
             
