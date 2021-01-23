    public static int? TryParse(string s)
    {
        int output;
        if (int.TryParse(s, out output))
            return output;
        else
            return null;
    }
