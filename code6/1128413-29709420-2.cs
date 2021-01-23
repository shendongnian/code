    private static bool checkSpecialCharacters(string Version1, string Version2)
    {
        Tuple<char, char>[] charRanges =
        {
            Tuple.Create('A', 'Z'),
            Tuple.Create('z', 'z'),
        };
        return !AllInRange(Version1, charRanges) || !AllInRange(Version2, charRanges);
    }
    private static bool AllInRange(string text, Tuple<char, char>[] charRanges)
    {
        foreach (char ch in text)
        {
            bool inRange = false;
            foreach (Tuple<char, char> range in charRanges)
            {
                if (range.Item1 <= ch && ch <= range.Item2)
                {
                    inRange = true;
                    break;
                }
            }
            if (!inRange)
            {
                return false;
            }
        }
        return true;
    }
