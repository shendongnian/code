    public static bool IsGroupValid(string group)
    {
        var indexes= group.Split(',').Select(x=>Int32.Parse(x.Trim('{').Trim('}'))));
        for (int i = 0; i < indexes.Length; i++)
        {
            if (indexes.Any(x=>x+1==indexes[i]))
                return false;
        }
        return true;
    }
