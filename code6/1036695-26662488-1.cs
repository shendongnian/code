    public static int? TryParse(string rawValue)
    {
        int output;
        if (int.TryParse(rawValue, out output))
            return output;
        else
            return null;
    }
