    private void UpdateLastLogonField(string userName)
    {
        PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
        UserPrincipal qbeuser = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userName);
        if (qbeuser != null && qbeuser.lastlogon != null)
        {
            lastlog.Text = qbeuser.LastLogon.ToString();
        } else {
            lastLog.Text = "Could not get last logon info";
        }
    }
