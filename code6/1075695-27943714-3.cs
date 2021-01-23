    private static int GetMatchIndex(Regex regex, Match match)
    {
        foreach(var name in regex.GetGroupNames())
        {
            var group = match.Groups[name];
            if(group.Success)
                return int.Parse(name); //group name is a number
        }
        return -1;
    }
