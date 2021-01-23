    public static bool IsGroupValid(List<int> group)
    {
        for (int i = 0; i < group.Count-1; i++)
        {
            if (group.Any(x=>Math.Abs(x+1)==group[i]))
                return false;
        }
        return true;
    }
