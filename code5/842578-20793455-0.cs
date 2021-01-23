    public ActionResult MyAction()
    {
        var myDefaultDescription = ""; //Replace with whatever you initialize ViewBag.Description with
        return View(new AdverModel{ description = myDefaultDescription });
    }
