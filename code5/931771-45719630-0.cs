    public ActionResult Validate(User user)
    {
         return new HttpStatusCodeResult((HttpStatusCode)500, 
                   "My custom internal server error.");
    }
    
