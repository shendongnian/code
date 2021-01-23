    private static int CountPatternAppearancesInString(string str, string pattern)
    {
        var count = str
            .Select(
                (_, index) =>
                    index < str.Length - pattern.Length + 1 &&
                    str.Skip(index)
                        .Take(pattern.Length)
                        .Zip(pattern, (strChar, patternChar) => strChar == patternChar)
                        .All(areEqual => areEqual))
            .Count(isMatch => isMatch);
        return count;
    }
