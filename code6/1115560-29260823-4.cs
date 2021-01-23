    public static class StringExtensions
    {
        static readonly List<char> _vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        public static bool VowelsOrdered(this string word)
        {
            var vowelList = word.Where(letter => _vowels.Any(v => letter == v));
            var expectedResult = vowelList.OrderBy(x => x);
            return vowelList.SequenceEqual(expectedResult);
        }
        // Could also be implemented with a lower complexity like this
        public static bool VowelsOrdered2(this string word)
        {
            char last = _vowels[0];
            foreach (var c in word)
            {
                if (_vowels.Any(x => x == c))
                {
                    if (c < last)
                        return false;
                    else
                        last = c;
                }
            }
            return true;
        }
    }
