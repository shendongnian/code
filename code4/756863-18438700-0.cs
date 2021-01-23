    IGroupSecurityService gss = (IGroupSecurityService)tfsConnection.GetService(typeof(IGroupSecurityService));
    Identity SIDS = gss.ReadIdentity(SearchFactor.AccountName, "Project Collection Valid Users", QueryMembership.Expanded);
    Identity[] UserId = gss.ReadIdentities(SearchFactor.Sid, SIDS.Members, QueryMembership.None);
    foreach (Identity user in UserId)
    {    
     // check if group or user
     if (!user.SecurityGroup)
     {
      Console.Writeln(user.DisplayName +" -> "+ user.Domain + "\" + user.AccountName + "-" + user.MailAddress);
     }
    }
