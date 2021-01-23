    public ActionResult ThisAction(bool divClicked)
    {
        ViewBag.Active = divClicked;    
        return View();
    }
