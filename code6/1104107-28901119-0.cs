    public Models.User GetUserInfo(Func<String> username)    {
      if (username != null)    {
        try{
           var User =  (from m in db.MstUsers
                    where m.UserName == Convert.ToString(username)
                    select new Models.User
                    {
                        UserName = m.UserName,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        EmailAddress = m.EmailAddress,
                        PhoneNumber = m.PhoneNumber
                    }).FirstOrDefault();
           return User;
        }
        catch {return new Models.User();}
      }else{return new Models.User();}
    }
