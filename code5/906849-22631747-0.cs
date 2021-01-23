    public static IEnumerable<string> ParseUrl(this string source)
    {
        var index = source.IndexOf("//");
        var indices = source.Select((x, idx) => new {x, idx})
                    .Where(p => p.x == '/' && p.idx > index + 1)
                    .Select(p => p.idx);
        var result = new List<string>();
        foreach (var idx in indices.Skip(1))
        {
           result.Add(source.Substring(0,idx));
        }
       return result;
    }
