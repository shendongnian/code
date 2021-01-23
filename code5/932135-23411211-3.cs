       [AllowAnonymous]
    public ActionResult Register()
    {
       List<SelectListItem> myList =new List<SelectListItem>();
       myList.Add(new SelectListItem { Value = bool.TrueString, Text = "Ja" });
       myList.Add(new SelectListItem { Value = bool.FalseString, Text = "Nee" });
        var Vdab = new SelectList(myList,"Value","Text");
           
        ViewBag.Vdab = Vdab;
        return View();
    }
             
