    public static string
        CustomNormalize(this string text)
    {
        foreach (var kvPair in NormalizationMapping.EncodingMapping)
        {
            text = kvPair.Value.Replace(text, kvPair.Key);
        }
        return text;
    }
