    public static string cleaner(string str)
    {
        var groups = new[] { "a", "e" };
        return Regex.Replace(str, "(?<a>[áàâ]+)|(?<e>[éèê]+)", m => groups.First(g => m.Groups[g].Success), RegexOptions.Compiled);
    }
