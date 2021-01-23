    List<string> Appname = new List<string>();
    roster = MURLEngine.GetUserFriendDetails(token, userId);
    foreach (string item in roster.RosterEntries)
    {
        if (item[0] == 'm' && item[1] >= '0' && item[1] <= '9')
        {
            var roster2 = MURLEngine.GetUserFriendDetails(token, item);
            foreach (string item2 in roster2)
            {
                if (item2[0] != 'm')
                {
                    bool found = false;
                    foreach (string app in appList)
                    {
                        if (app.AppName == item2)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found) Appname.Add(item2);
                }
            }
        }
    }
