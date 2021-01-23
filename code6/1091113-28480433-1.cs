    private IEnumerable<string> FilterShortestPath(IEnumerable<string> paths, params char[] chars)
    {
        if(paths == null || !paths.Any()) 
            return Enumerable.Empty<string>();
        int minCount = paths.Min(str => (str ?? "").Count(chars.Contains));
        return paths.Where(str => (str ?? "").Count(chars.Contains) == minCount);
    }
