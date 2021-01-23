    public ApplicationUserManager UserManager
    {
        get
        {
            return HttpContext.GetOwinContext()
               .GetUserManager<ApplicationUserManager>();
        }
    }
