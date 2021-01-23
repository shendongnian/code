    public static bool IsGroupValid(List<int> group)
    {
        for (int i = 0; i < group.Count; i++)
        {
            if (group.Any(x=>x+1==group[i]))
                return false;
        }
        return true;
    }
