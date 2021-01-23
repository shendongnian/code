    public ActionResult ThisAction(bool divClicked)
    {
        if(divClicked == true)
        {
            ViewBag.Active = true;
        }
        else
        {
             ViewBag.Active = false;
        }
    
        return View();
    }
