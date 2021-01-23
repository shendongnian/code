    public Models.User GetUserInfo(Func<String> username)    {
      User = new Models.User();
      if (username == null){return User;}
      try{
           User =  db.MstUsers.Where(
                      x => x.UserName==Convert.ToString(username)
                   ).FirstOrDefault();
      }
      return User;
    }
