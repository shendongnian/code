    public static bool OnlyOnceCheck(string input)
    {
        var set = new HashSet<char>();
        for (int i = 0; i < input.Length; i++)
            if (!set.Add(input[i]))
                return false;
        return true;
    }
