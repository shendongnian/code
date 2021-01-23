    private static IEnumerable<string> CreateSplitDeferredEnumerable(
        string str,
        char delimiter)
    {
        var buffer = new StringBuilder();
        foreach (var ch in str) {
            if (ch == delimiter) {
                yield return buffer.ToString();
                buffer.Length = 0;
            } else {
                buffer.Append(ch);
            }
        }
        if (buffer.Length != 0) {
            yield return buffer.ToString();
        }
    }
    public static IEnumerable<string> SplitDeferred(this string self, char delimiter)
    {
        if (self == null) { throw new ArgumentNullException("self"); }
        return CreateSplitDeferredEnumerable(self, delimiter);
    }
