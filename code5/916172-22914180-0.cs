    public ActionResult Sample1()
    {
    
        TempData["Test"] = "Test1"
        return RedirectToAction("Sample2");
    }
    
    public ActionResult Sample2()
    {
        var test= TempData["Test"] as string
    
        return View( test);
    }
