    public ActionResult SaveRecord(FormCollection formStuff)
    {
        if (ModelState.IsValid)
        {
             try
             {
                 using ( var context = blogContextFactory.Create())
                 {
                     // do you stuff here!
                 }
             }
    
        }
    
    }
