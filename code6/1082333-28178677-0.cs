     /// <summary>
    /// Splits a string into tokens.
    /// </summary>
    /// <param name="s">The string to split.</param>
    /// <param name="isSeparator">
    /// A function testing if a code point at a position
    /// in the input string is a separator.
    /// </param>
    /// <returns>A sequence of tokens.</returns>
    IEnumerable<string> Tokenize(string s, Func<string, int, bool> isSeparator = null)
    {
        if (isSeparator == null) isSeparator = (str, i) => !char.IsLetterOrDigit(str, i);
        
        int startPos = -1;
        
        for (int i = 0; i < s.Length; i += char.IsSurrogatePair(s, i) ? 2 : 1)
        {
            if (!isSeparator(s, i))
            {
                if (startPos == -1) startPos = i;
            }
            else if (startPos != -1)
            {
                yield return s.Substring(startPos, i - startPos);
                startPos = -1;
            }
        }
        
        if (startPos != -1)
        {
            yield return s.Substring(startPos);
        }
    }
