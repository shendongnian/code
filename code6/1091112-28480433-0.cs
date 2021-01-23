    private IEnumerable<string> FilterShortestPath(IEnumerable<string> paths, params char[] chars)
    {
        int minCount = paths.Min(str => (str ?? "").Count(chars.Contains));
        return paths
            .Where(str => (str ?? "").Count(chars.Contains) == minCount);
    }
