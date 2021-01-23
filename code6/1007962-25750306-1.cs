    public bool HasAccess(string path, string user)
    {
    System.Security.Principal.SecurityIdentifier sid = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null);
    System.Security.Principal.NTAccount acct = sid.Translate(typeof(System.Security.Principal.NTAccount)) as System.Security.Principal.NTAccount;
    bool userHasAccess = false;
    if( Directory.Exists(path))
    {
      DirectorySecurity sec = Directory.GetAccessControl(path);
      AuthorizationRuleCollection rules = sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
      foreach (AccessRule rule in rules)
      {
        // check is the Everyone account is denied
        if (rule.IdentityReference.Value == acct.ToString() && 
            rule.AccessControlType == AccessControlType.Deny)
        {
          userHasAccess = false;
          break;
        }
        if (rule.IdentityReference.Value == user)
        {
          if (rule.AccessControlType != AccessControlType.Deny)                 
            userHasAccess = true;
          else
            userHasAccess = false;
          break;
        }
      }
    }
    return userHasAccess;
    }            
             
