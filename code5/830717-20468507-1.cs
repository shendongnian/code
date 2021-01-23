    partNumbers.OrderBy(TryParseNullableInt).ThenBy(x => x);
    private static int? TryParseNullableInt(string source)
    {
        int parseResult; 
        return int.TryParse(x, out parseResult) 
            ? parseResult 
            : null as int?;
    }
