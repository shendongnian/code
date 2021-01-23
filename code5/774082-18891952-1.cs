    static IEnumerable<string> GuessPatterns(string text, CultureInfo culture)
    {
        DateTime ignored;
        return GetDateTimePatterns(culture)
            .Where(pattern => DateTime.TryParseExact(text, pattern, culture,
                                                 DateTimeStyles.None, out ignored))
        }
    }
