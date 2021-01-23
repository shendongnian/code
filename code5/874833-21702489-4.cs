    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByName(HttpContext.Current.User.Identity.Name);
            PatientPortalPrincipal newUser = new PatientPortalPrincipal(user);
            newUser.BirthDate = user.BirthDate;
            newUser.InvitationCode = user.InvitationCode;
            newUser.PatientNumber = user.PatientNumber;
            //Claim cPatient = new Claim(typeof(PatientPortalPrincipal).ToString(), );
            HttpContext.Current.User = newUser;
        }
    }
