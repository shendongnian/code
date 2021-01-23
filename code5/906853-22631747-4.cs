    public static IEnumerable<string> ParseUrl(this string source)
    {
        if(!Uri.IsWellFormedUriString(source, UriKind.Absolute)) 
             throw new ArgumentException("The URI Format is invalid");
        var index = source.IndexOf("//");
        var indices = source.Select((x, idx) => new {x, idx})
                    .Where(p => p.x == '/' && p.idx > index + 1)
                    .Select(p => p.idx);
        var result = new List<string>();
        // Skip the first index because we don't want http://site
        foreach (var idx in indices.Skip(1))
        {
           result.Add(source.Substring(0,idx));
        }
        result.Add(source); // last part is the url itself
        return result;
    }
