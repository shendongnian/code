    //Define that we are debugging
    #define DEBUG    
    public ActionResult DoSomething()
    {
        //Determine if this is a debug build
        //If it is, then we want to exclude the authentication verification
        //portion of the code
        
        //Include the code if DEBUG has not been defined
        #if !DEBUG
        if(!HttpContext.User.Identity.IsAuthenticated)
        {
           //Not authenticated
           return new HttpUnauthorizedResult();
        }
        #endif
        //Authenticated
        DoOtherStuff();
    }
