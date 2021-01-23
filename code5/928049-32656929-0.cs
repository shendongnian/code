    // Is in AD Group?
    private static bool IsInADGroup(String inGroup)
    {
        foreach (System.Security.Principal.IdentityReference group in
            System.Web.HttpContext.Current.Request.LogonUserIdentity.Groups)
        {
            String sGroup = (group.Translate(typeof(System.Security.Principal.NTAccount)).ToString());
            if (sGroup.Equals(inGroup))
                return true;
        }
        return false;
    }
