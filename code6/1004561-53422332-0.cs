    public void GetUserInfoFromUsernameAndPassword(string userName, string password, out int userID, out string userRole)
    {
      var userInfo = from u in STE.tblUsers
      where u.UserName == userName
      && u.PWD == password
      select new
      {
        userID = u.UserID,
        userRole = u.UserRole
      };
    }
