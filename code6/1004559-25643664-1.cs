    public IEnumerable<dynamic> GetUserInfoFromUsernameAndPassword(string userName, string password)
    {
        return STE.tblUsers
                .Where(x => x.UserName == userName && x.PWD == password)
                .Select(x => new
                {
                    x.UserID,
                    x.UserRole
                });
    }
