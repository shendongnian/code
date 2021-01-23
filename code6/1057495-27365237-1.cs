    public static class ToolsEx
    {
        public static string ToCsvString(this string[][] lines)
        {
            var query = lines.Select(l=>string.Join(",", l));
            var result = query.Aggregate(new StringBuilder(), (sb, v) => sb.AppendLine(v));
            return result.ToString();
        }
    }
