    /// <summary>
    /// Split a string into pairs of two characters.
    /// </summary>
    /// <param name="str">The string to split.</param>
    /// <returns>An enumerable sequence of pairs of characters.</returns>
    /// <remarks>
    /// When the length of the string is not a multiple of two,
    /// the final character is returned on its own.
    /// </remarks>
    public static IEnumerable<string> SplitIntoPairs(string str)
    {
        if (str == null) throw new ArgumentNullException("str");
        int i = 0;
        for (; i + 1 < str.Length; i += 2)
        {
            yield return str.Substring(i, 2);
        }
        if (i < str.Length)
            yield return str.Substring(str.Length - 1);
    }
