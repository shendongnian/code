    public static class StringExtensions
    {
        static readonly List<char> _vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        public static bool VowelsOrdered(this string word)
        {
            var vowelList = word.Where(letter => _vowels.Any(v => letter == v));
            var expectedResult = vowelList.OrderBy(x => x);
            return vowelList.SequenceEqual(expectedResult);
        }
    }
