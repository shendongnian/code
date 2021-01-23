    public static bool Validate(this string source)
    {
        string pattern = "[A-Z]{2}[0-9]{4}";
        return !source.StartsWith("##") &&
               !source.EndsWith("##") &&
               source.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                     .All(x => Regex.IsMatch(x, pattern));
    }
