    if(WebSecurity.UserExists(username)){ /// ur logic }
    //or
    WebSecurity.CreateUserAndAccount(username, password);
    //or
    System.Web.Security.Roles.AddUserToRole(username, UserRole);
