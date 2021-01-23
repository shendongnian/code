    public string GetInfo(string username)
    {   
        Reddit reddit = new Reddit();
        
        if (!LoggedIn(user))
        {
           reddit.LogIn("user123","pass123");
        }
        return reddit.GetUserInfo(username);
    }
