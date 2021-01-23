    private static void sortList()
    {
        var dates = getDates();
        var sorted = dates.OrderBy(f1).ThenByDescending(f2);
    }
    private static DateTime f1(string parse)
    {
        return DateTime.Parse(parse.Substring(0, 10));
    }
    private static int f2(string parse)
    {
        int sort;
        if (parse.Length > 10) int.TryParse(parse.Substring(18, 1), out sort);
        else sort = 0;
        return sort;
    }
