    public ActionResult ActionA(){
     ViewBag.ReturnUrl = "ActionA";
     return View();
    }
    
    public ActionResult ActionB(){
     ViewBag.ReturnUrl = "ActionB";
     return View();
    }
    
    public ActionResult Declined(){
     return RedirectToAction(ViewBag.ReturnUrl);
    }
