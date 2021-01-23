    public static class MyStringExtensions
    {
    public static bool Like(this string toSearch, string toFind)
    {
        return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch = > @"\" + ch).Replace('_', '.').Replace(" % ", ".*") + @"\
                z ", RegexOptions.Singleline).IsMatch(toSearch);
     }
    }
