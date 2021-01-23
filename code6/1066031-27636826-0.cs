    public User GetUserByEmail(ClientContext clientContext, string email)
    {
     try
       {
         ClientResult<Microsoft.SharePoint.Client.Utilities.PrincipalInfo> persons =
         Microsoft.SharePoint.Client.Utilities.Utility.ResolvePrincipal(clientContext,                         clientContext.Web, email,
         Microsoft.SharePoint.Client.Utilities.PrincipalType.User,Microsoft.SharePoint.Client.Utilities.PrincipalSource.All, null, true);
         clientContext.ExecuteQuery();
         Microsoft.SharePoint.Client.Utilities.PrincipalInfo person = persons.Value;
         User user = clientContext.Web.SiteUsers.GetByLoginName(person.LoginName);
         clientContext.ExecuteQuery();
         return user;
       }
       catch
       {
         return null;
       }
    }
