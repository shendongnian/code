    public IEnumerable<UserInfo> GetUserInfoFromUsernameAndPassword(string userName, string password)
    {
        return STE.tblUsers
                .Where(x => x.UserName == userName && x.PWD == password)
                .Select(x => new UserInfo
                {
                    UserID = x.UserID,
                    UserRole = x.UserRole
                });
    }
    public void Iterate()
    {
        foreach (var userInfo in GetUserInfoFromUsernameAndPassword("username", "Password"))
            Console.WriteLine(userInfo); // Do other stuff here...
    }
