    using SP = Microsoft.SharePoint.Client;
    //...
    // resolve user principal using regular login name or e-mail:
    var userPrincipal = SP.Utilities.Utility.ResolvePrincipal(
      context, 
      context.Web, 
      "DOMAIN\\user", // normal login name
      SP.Utilities.PrincipalType.User,
      SP.Utilities.PrincipalSource.All,
      context.Web.SiteUsers,
      false);
    context.ExecuteQuery();
    // ensure that the user principal was resolved:
    if (userPrincipal.Value == null)
      throw new Exception("The specified user principal could not be resolved");
    // get a User instance based on the encoded login name from userPrincipal
    var user = context.Web.SiteUsers.GetByLoginName(userPrincipal.LoginName);
    context.Load(user);
    context.ExecuteQuery();
