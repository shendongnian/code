    public List<string> connect(String query_physician, String query_institution)
    {
        ...
        return Regex.Matches(customSearchResult, @"(?<=""link""\:\s"")[^""]*(?="")")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToList();
    }
