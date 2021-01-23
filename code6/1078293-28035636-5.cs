    public static bool IsGroupValid(List<int> group)
    {
        for (int i = 0; i < group.Count-1; i++)
        {
            if (group[i] + 1 == group[i + 1])
                return false;
        }
        return true;
    }
