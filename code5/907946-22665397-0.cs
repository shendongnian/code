    /// <summary>
    /// Gets all lines containing the "match" including "before" lines before and "after" lines after.
    /// </summary>
    /// <param name="lines">The original lines.</param>
    /// <param name="match">The match that shall be found.</param>
    /// <param name="before">The number of lines before the occurence.</param>
    /// <param name="after">The number of lines after the occurence.</param>
    /// <returns>All lines containing the "match" including "before" lines before and "after" lines after.</returns>
    private List<string> GetMatchingLines(List<string> lines, string match, int before = 0, int after = 0)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < lines.Count; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                continue;
            }
            if (Regex.IsMatch(lines[i], match, RegexOptions.IgnoreCase))
            {
                for (int j = i - before; j < i + after; j++)
                {
                    if (j >= 0 && j < lines.Count)
                    {
                        result.Add(lines[j]);
                    }
                }
            }
        }
        return result;
    }
