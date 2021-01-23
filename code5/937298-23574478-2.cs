    public static string StripCrap(string input)
    {
        char[] nonCrapChars = {'/', '-', '_'};
        return input.Where(c => char.IsNumber(c) || nonCrapChars.Contains(c)).Aggregate("", (current, c) => current + c);
    }
