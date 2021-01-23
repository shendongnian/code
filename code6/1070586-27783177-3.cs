    // GET: odata/Users
    [EnableQuery]
    public IQueryable<UserInfo> GetUsers()
    {
        List<UserInfo> lstUserInfo = new List<UserInfo>();
                    
        foreach(User usr in db.Users)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Id = usr.Id;
            userInfo.Name = usr.Name;
            userInfo.Email = usr.Email;
    
            lstUserInfo.Add(userInfo);
        }
    
        return lstUserInfo.AsQueryable();
    }
