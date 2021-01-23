    public ParseStatus TryParseNullableInt(string input, out int? output)
    {
        int tempInteger;
        output = null;
        if (input == null) return ParseStatus.Success;
        if (input == string.Empty) { output = 0; return ParseStatus.Derived; }
        if (!int.TryParse(input, out tempInteger)) {
            if (ParseWords(input, out tempInteger)) { // "Twenty Three" = 23
                output = tempInteger;
                return ParseStatus.Derived;
            }
            long tempLong;
            if (long.TryParse(input, out tempLong))
                return ParseStatus.OutOfRange;
            return ParseStatus.NotParsable;
        }
        output = tempInteger;
        return ParseStatus.Success;
    }
