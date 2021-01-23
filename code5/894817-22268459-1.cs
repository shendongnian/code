    public static string ReplaceLast(string str, string search, string newText)
    {
        int ind = str.LastIndexOf(search);
        if (ind < 0)
        {
            return str;
        }
        return str.Substring(0, ind) + newText + str.Substring(ind + search.Length);
    }
