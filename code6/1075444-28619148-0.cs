    protected override bool IsUserAuthorized(string userName)
    {
        var user = db.Users.Where(u => u.username = userName);
        if(user.Any())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
