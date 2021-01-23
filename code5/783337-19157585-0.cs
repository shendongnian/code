    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        MembershipUser u = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        u.LastActivityDate = DateTime.Now.AddMinutes(-Membership.UserIsOnlineTimeWindow);
        Membership.UpdateUser(u);
    }
