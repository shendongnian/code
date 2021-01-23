    public static bool IsGroupValid(string group)
    {
        var indexes= group.Split(' ').Select(x=>Int32.Parse(x)).ToList();
        for (int i = 0; i < indexes.Count; i++)
        {
            if (indexes.Any(x=>x+1==indexes[i]))
                return false;
        }
        return true;
    }
