    public ActionResult ThisAction(bool? divClicked)
    {
        ViewBag.Active = divClicked.HasValue ? divClicked : false;    
        return View();
    }
