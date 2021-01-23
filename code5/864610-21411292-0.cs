    try{    
    var userName = "bob";
        using (var pc = new PrincipalContext(ContextType.Domain)
        {
              var user = UserPrincipal.FindByIdentity(pc, userName);
              user.ChangePassword(oldpassword, newpassword); //Checks password policy
              //or
              user.SetPassword(newpassword); //Not positive checks password policy but I believe it 2.
        }
    }
    catch(PasswordException ex)
    {
    //do something with ex
    }
