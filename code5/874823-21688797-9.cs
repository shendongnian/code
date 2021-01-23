    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
         CustomPrincipal customUser = new CustomPrincipal(User.Identity.Name);
         customUser.BirthDate = DateTime.Now;
         customUser.InvitationCode = "1234567890A";
         customUser.PatientNumber = 100;
         HttpContext.Current.User = customUser;
    }
