    public static bool IsGroupValid(List<int> numbers, List<int> group)
    {
        for (int i = 0; i < group.Count-1; i++)
        {
            if (numbers.IndexOf(group[i]) + 1 == numbers.IndexOf(group[i + 1]))
                return false;
        }
        return true;
    }
