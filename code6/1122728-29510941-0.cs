    public static IEnumerable<string> SplitIntoChunks(string s, params int[] lengths)
    {
        int start = 0;
        foreach (var length in lengths)
        {
            if (start >= s.Length)
                yield return "";
            else if ((start + length) >= s.Length)
                yield return s.Substring(start);
            else
                yield return s.Substring(start, length);
            start += length;
        }
    }
