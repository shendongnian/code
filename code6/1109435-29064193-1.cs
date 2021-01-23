    public static string ToHtml(List<int> tags)
    {
        var found = Values.Where(v => tags.Contains(v.Key))
                          .Select(v => v.Value.ToHtml());
        
        return found.Any()
            ? string.Join("", found.ToArray()) + " "
            : string.Empty;
    }
