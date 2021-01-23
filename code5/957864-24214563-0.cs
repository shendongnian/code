    [HttpPost]
    public ViewResult PostActionMethod(CommonViewModel commonViewModel)
    {
       if (ModelState.IsValid)
       {
           //your code follows
       }
       
       return RedirectToAction("GetActionMethod", commonViewModel);
    }
    
    [HttpGet]
    public ViewResult GetActionMethod(CommonViewModel commonViewModel)
    {
       //your code follows
    
       return View(commonViewModel);
    }
