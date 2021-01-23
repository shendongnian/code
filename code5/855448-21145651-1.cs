    private static string RenderString(IEnumerable<IEnumerable<string>> cp)
    {
        var sb = new StringBuilder();
    
        foreach (var item in cp)
        {
            sb.AppendLine(item.Aggregate((a, b) => a + b));
        }
        return sb.ToString();
    }
