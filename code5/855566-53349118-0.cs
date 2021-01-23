     public ApplicationSignInManager SignInManager
     {
       get
       {
        return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
       }
        private set
        {
         _signInManager = value;
        }
      }
