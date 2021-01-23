    public string GetUserName()
    {
        var user = Membership.GetUser();
        if(user == null)
        {
            return "Anonymous";
        }
        return user.UserName;
    }
