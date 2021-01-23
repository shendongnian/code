    public static bool Check(string s)
    {
        Regex regex = new Regex(@"^Q\d+null$");
        Match match = regex.Match(s);
        return match.Success;
    }
