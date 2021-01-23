    // could easily be an extension method
    public static string ReplacingChars(string source, char[] toReplace, string withThis)
    {
        return string.Join(withThis, source.Split(toReplace, StringSplitOptions.None));
    }
    // usage:
    images = ReplacingChars(images, new [] {',', '"'}, " ");
