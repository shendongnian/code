    public static IEnumerable<int> CharPositions(string input, char match)
    {
       return input
             .Select((x, idx) => new { x, idx })
             .Where(c => c.x == match)
             .Select(c => c.idx);
    }
