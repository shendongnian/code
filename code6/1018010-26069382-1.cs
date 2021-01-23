    private static Func<string, string> CreateReplaceFn()
    {
        var map = new List<Tuple<string, string>>
        {
            Tuple.Create("AM|PM", "<time>"),
            // ... 20 more
            Tuple.Create("\\.[0-9]{3}", "<ms>"),
            Tuple.Create("[a-z0-9]{8}-[0-9a-z]{4}-[0-9a-z]{4}-[0-9a-z]{4}-[0-9a-z]{12}", "<guid>"),
            Tuple.Create("_\\d+_", "_<number>_")
        };
        var reStr = String.Join("|", map.Select(r => "(" + r.Item1 + ")"));
        var regex = new Regex(reStr, RegexOptions.Compiled);
        return str => regex.Replace(str, match =>
        {
            for (var i = 1; i <= match.Groups.Count; ++i)
            {
                if (match.Groups[i].Success)
                    return map[i - 1].Item2;
            }
            return match.Value;
        });
    }
