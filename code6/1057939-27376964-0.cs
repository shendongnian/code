    [Authorize(Roles = "Admin")]
     public ActionResult method1()
      {
           
            return View("View1");
       }
     [Authorize(Roles = "Cook")]
     public ActionResult method2()
     {
           
            return View("View2");
    }
  
