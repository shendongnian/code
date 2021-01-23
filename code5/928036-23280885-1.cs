    public static string RemoveMultiSpace(string input)
    {
        var indices = input
                  .Select((x, idx) => new { x, idx })
                  .Where(c => char.IsUpper(c.x))
                  .Select(c => c.idx);
        return new string(input
                .Where((x, idx) =>  indices.Any(c => c - 1  == idx) || x != ' ')
                .ToArray());
    }
