    List<Setting> FindItemsInList(List<Setting> settings, string val)
    {
        var result = new List<Setting>();
        var searchRegEx = new RegEx(@"\b" + val + @"\b");
        foreach (var s in settings)
        {
            if (searchRegEx.IsMatch(s.UserIDList))
            {
                result.Add(s);
            }
        }
        return result;
    }
