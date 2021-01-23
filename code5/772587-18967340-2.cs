    List<string> Appname = new List<string>();
    roster = MURLEngine.GetUserFriendDetails(token, userId);
    foreach (string item in roster.RosterEntries)
    {
        if(item == null || item.Trim().Length < 1) continue;
        if (item[0] == 'm' && Convert.ToInt32(item[1]) >= 0 && Convert.ToInt32(item[1]) <= 9)
        {
            var roster2 = MURLEngine.GetUserFriendDetails(token, item);
            foreach (string item2 in roster2.RosterEntries)
            {
                if(item2 == null || item2.Trim().Length < 1) continue;
                if (item2[0] != 'm')
                {
                    bool found = false;
                    foreach (string app in appList)
                    {
                        if(app == null || app.Trim().Length < 1) continue;
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
