    public ActionResult Post(PostModel post)
    {
        // The user will be logged in because you just gave them the
        // authentication cookie
        if(!HttpContext.User.Identity.IsAuthenticated)
        {
            return new HttpUnauthorizedResponse();
        }
        else
        {
           User user = GetLoggedInUser(); //Returns user
           Post createdPost = new Post
           {
              //ect..
              User = user
           };
           
           // Save post
           return View();
        }
    }
