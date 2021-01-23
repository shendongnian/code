    public static string ReplaceWithPatterns(this string input, IEnumerable<string> patterns, char replacement)
    {
        var patternsPositions = patterns.Select(p => 
               new { Pattern = p, Index = input.IndexOf(p) })
               .Where(i => i.Index > 0);
        var result = new string(replacement, input.Length);
        if (!patternsPositions.Any()) // no pattern in the input
            return result;
        foreach(var p in patternsPositions)
            result = result.Insert(p.Index, p.Pattern); // return patterns back
        return result;
    }
