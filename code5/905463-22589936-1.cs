    static string Replace(string input, int index, string replacement)
    {
        int matchIndex = 0;
        return Regex.Replace(input, @"\d+", m => matchIndex++ == index ? replacement : m.Value);
    }
