    public static IEnumerable<string> Split(this string toSplit, string[] separators)
    {
        if (string.IsNullOrEmpty(toSplit))
            yield break;
        StringBuilder sb = new StringBuilder();
        foreach (var c in toSplit)
        {
            var s = sb.ToString();
            var sep = separators.FirstOrDefault(i => s.Contains(i));
            if (sep != null)
            {
                yield return s.Replace(sep, string.Empty);
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }
        if (sb.Length > 0)
            yield return sb.ToString();
    }
