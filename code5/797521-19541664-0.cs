    public static bool ContainsToken(string value, string token, char delimiter = '.')
    {
        if (string.IsNullOrEmpty(token)) return false;
        if (string.IsNullOrEmpty(value)) return false;
        int lastIndex = -1, idx, endIndex = value.Length - token.Length, tokenLength = token.Length;
        while ((idx = value.IndexOf(token, lastIndex + 1)) > lastIndex)
        {
            lastIndex = idx;
            if ((idx == 0 || (value[idx - 1] == delimiter))
                && (idx == endIndex || (value[idx + tokenLength] == delimiter)))
            {
                return true;
            }
        }
        return false;
    }
