        ArrayList UserList = new ArrayList();
        var SkypeClient = new SKYPE4COMLib.Skype();
        foreach (User User in skype.Friends)
        {
            if (User.BuddyStatus == SKYPE4COMLib.TBuddyStatus.budFriend)
            {
                UserList.Add(User.Handle);
            }
        }
