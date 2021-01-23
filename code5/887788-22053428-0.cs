    public static bool OnlyOnceCheck(string input)
    {
        var set = new HashSet<char>();
        return input.Any(x => !set.Add(x));
    }
