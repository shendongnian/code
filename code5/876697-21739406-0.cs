    public static string ToHumanReadableString<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> dictionary)
    {
        if (dictionary.IsNull())
        {
            return "{null}";
        }
        StringBuilder sb = new StringBuilder();
        foreach (var kvp in dictionary)  // note change
        {
            if (!kvp.Value == null)   // note change
            {
                sb.AppendLineAndFormat("{0}={1}", kvp.Key.ToString(), kvp.Value.ToString());
            }
            else
            {
                sb.AppendLineAndFormat("{0}={null}", kvp.Key.ToString());
            }
        }
        return sb.ToString();
    }
