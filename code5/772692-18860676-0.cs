    public static IEnumerable<string> FirstNSuccessiveStrings(int n, string needle, IEnumerable<IEnumerable<string>> lists, bool exceptIfNeedle = true) {
        bool afterNeedle = false;
        foreach (var list in lists)
            foreach (var @string in list) {
                if (afterNeedle) {
                    if (exceptIfNeedle && (@string == needle))
                        continue;
                    yield return @string;
                    if (0 == --n)
                        yield break;
                }
                afterNeedle = @string == needle;
            }
    }
