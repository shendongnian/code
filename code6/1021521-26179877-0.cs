    List<int> FindItemsInList(List<Setting> settings, string val)
    {
        var result = new List<int>();
        var searchRegEx = new RegEx(@"\b" + val + @"\b");
        foreach (var s in settings)
        {
            if (searchRegEx.IsMatch(s.UserIDList))
            {
                result.Add(s.SettingID);
            }
        }
        return result;
    }
