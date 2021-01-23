    // incoming single-string matrix:
    String input = @"1 2 3 4 5
    2 3 4 5 6
    3 4 5 6 7
    4 5 6 7 8
    5 6 7 8 9";
    // processing:
    String[][] result = input
        // Divide in to rows by \n or \r (but remove empty entries)
        .Split(new[]{ '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
        // no divide each row into columns based on spaces
        .Select(x => x.Split(new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries))
        // case from IEnumerable<String[]> to String[][]
        .ToArray();
