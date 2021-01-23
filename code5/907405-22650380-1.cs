    public static string ToHypenCase(this string source)
    {
        var chars = source.ToList();
        for (int i = 0; i < chars.Count -1; i++)
        {
            if (!char.IsWhiteSpace(chars[i]) && char.IsUpper(chars[i + 1]))
            {
                chars[i + 1] = char.ToLower(chars[i + 1]);
                chars.Insert(i+1,'-');
            }
        }
        return new string(chars.ToArray());
    }
