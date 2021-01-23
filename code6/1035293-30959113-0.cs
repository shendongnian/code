    ArrayList UserList = new ArrayList();
        var SkypeClient = new SKYPE4COMLib.Skype();
        foreach (User User in skype.Friends)
        {
            if (User.IsAuthorized == True)
            {
                UserList.Add(User.Handle);
            }
        }
