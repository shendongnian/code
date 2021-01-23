    //find the user
    User oUser = Context.User.FirstOrDefault(u => u.Email == this.Email);
    if (oUser != null)
    {
    var oUserType = (dynamic)null;
    int iMaxAttempts;
    bool bValidIp = false; 
    
    var ModelUser = new UserModel(){ UserId = oUser,UserId, etc.};
           
    //authenticate the type of user
    switch (this.Type)
    {
       case UserType.Xml:
           oUserType = oUser.UserXml; 
           
          break;
      case UserType.Api:
          oUserType = oUser.UserApi; 
                 
          break;
      default:
          oUserType = null;
          break;
    }
    ModelUser.Validate();
    }
