    /// <summary>
    /// Function that allows for substring regardless of length of source string (behaves like VB6 Mid$ function)
    /// </summary>
    /// <param name="s">String that will be substringed</param>
    /// <param name="start">start index (0 based)</param>
    /// <param name="length">length of desired substring</param>
    /// <returns>Substring if valid, otherwise returns original string</returns>
    public static string Mid(string s, int start, int length)
    {
        if (start > s.Length || start < 0)
        {
            return s;
        }
        if (start + length > s.Length)
        {
            length = s.Length - start;
        }
        string ret = s.Substring(start, length);
        return ret;
    }
