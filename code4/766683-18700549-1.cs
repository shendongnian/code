    public static int? TryParse(string s)
    {
        int result;
        if (int.TryParse(s, out result))
        {
            return result;
        }
        return null;
    }
    var res = new string[] { "1", "2", "a" }.Select(x => TryParse(x).GetValueOrDefault());
