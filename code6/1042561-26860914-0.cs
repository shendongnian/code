    /// <summary>
    /// Converts a wildcard to a regex.
    /// </summary>
    /// <param name="pattern">The wildcard pattern to convert.</param>
    /// <returns>A regex equivalent to the given wildcard.</returns>
    private static string WildcardToRegex(string pattern)
    {
    	return "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
    }
