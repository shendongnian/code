        ArrayList UserList = new ArrayList();
        var SkypeClient = new SKYPE4COMLib.Skype();
        foreach(SKYPE4COMLib.Group Group in SkypeClient.CustomGroups)
        {
                if (Group.DisplayName == "<specify the usergroup name here>")
                {
                    foreach (SKYPE4COMLib.User User in Group.Users)
                    {
                        if (User.BuddyStatus == SKYPE4COMLib.TBuddyStatus.budFriend)
                        {
                            UserList.Add(User.Handle);
                        }
                    }
                }
        }
