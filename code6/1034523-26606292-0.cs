    var result = from userlist in context.UserMasters
                 where userlist.UserName.Equals(username)
     
    // May be better (if usernames are unique):
    var result = context.UserMasters.SingleOrDefault(u=>u.UserName == username);
     
    if(result == null){
       // Did not find any user(s)
    }
     
    // If you want a case sensitive password check
    if(result.UserPassword == pass){
      // The password is correct
    }
    else
    {
          throw new Exception("Invalid password");
    }
     
    // If you don't
    if(result.UserPassword.Equals(pass, StringComparison.InvariantCulture)){
      // The password is correct
    }
