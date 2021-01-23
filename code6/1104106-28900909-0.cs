    public List<Models.User> GetUserInfo(Func<String> username)
    {
        List<Models.User> UserInfo = new List<Models.User>();
    if (username != null)
    {
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
            if (User != null)
            {
                UserInfo.Add(User);
            }
        }
        catch
        {
            UserInfo = new List<Models.User>();
        }
    }
    return UserInfo;
    }
