     LinkedList<string> allApps2 = new LinkedList<string>();// linkedlist here
            roster = MURLEngine.GetUserFriendDetails(token, userId);
            var usersfriends = from elements in roster.RosterEntries
                               where elements[0] == 'm' && elements[1] >= '0' && elements[1] <= '9'
                               select elements;
            foreach (string userid in usersfriends)
            {
                roster = MURLEngine.GetUserFriendDetails(token, userid);
                var usersapps = from elements in roster.RosterEntries
                                where elements[0] != 'm'
                                select elements;
                foreach(var userapp in usersapps)// add _all the apps_ to list. Will be distinct-ed later
                {
                    allApps2.AddLast(userapp);// don't worry, it works for O(1)
                }
                
            }
    
            var allApps = allApps2.Distinct().ToList();
    
            int countapps = 0;
            LinkedList<string> Appname2 = new LinkedList<string>();// linkedlist here
            countapps = appList.Count();
    
            for (int y = 0; y < countapps; y++)
            {
                foreach (string li in allApps)  // 
                {
                    bool istrueapp = appList.ElementAt(y).AppName.Equals(li);
                    if (istrueapp == true)
                    {
                        Appname2.AddLast(appList.ElementAt(y).AppName);// and here
                    }
                }
            }
    
            var AppName = Appname2.ToList();// and you've got you List<string> as the result
