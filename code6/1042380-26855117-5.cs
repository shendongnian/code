    public Maybe<int?> TryParseNullableInt(string input)
    {
        if (input == null) return Maybe.Success(null);
        if (input == string.Empty) { return Maybe.Derived(0); }
        int tempInteger;
        if (!int.TryParse(input, out tempInteger)) {
            if (ParseWords(input, out tempInteger)) { // "Twenty Three" = 23
                return Maybe.Derived(tempInteger);
            }
            long tempLong;
            if (long.TryParse(input, out tempLong))
                return Maybe.OutOfRange();
            return Maybe.NotParsable();
        }
        return Maybe.Success(tempInteger);
    }
