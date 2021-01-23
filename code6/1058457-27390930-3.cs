    [HttpPost]
    public ActionResult SomeThing(int randomParam)
    {
        if (randomParam == 0)
        { 
            return Json("Zero!"); 
        }
        else if (randomParam == 1)
        {
            return View("Not zero!");
        }
        else
        {
            return HttpNotFound("Error: I can only find zeroes and ones");
        }
    }
