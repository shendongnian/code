    public UserValidationResult CheckUser(string userName, string userPassword)
    {
      var user = GetUser(username, userPassword);
      return user != null ? 
           new UserValidationResult { Status = LoginStatus.Sucess, User = user }
         : new UserValidationResult { Status = LoginStatus.Failed; }
    }
