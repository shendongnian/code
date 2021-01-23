    public static class StringExtensions
    {
        public static IEnumerable<string> Split(this string toSplit, params char[] splits)
        {
            if (string.IsNullOrEmpty(toSplit))
                yield break;
            StringBuilder sb = new StringBuilder();
            foreach (var c in toSplit)
            {
                if (splits.Contains(c))
                {
                    yield return sb.ToString();
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
    }
