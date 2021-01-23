    [HttpPost]
    public ContentResult Login(string username, string password)
    {
        // Your login logic, assuming it sets the below user identity
        return Content(string.Format("Hello {0}", HttpContext.User.Identity.Name));
    }
