        static readonly string[] _vowels = { "a", "e", "i", "o", "u" };
        static readonly string[] _consonants =
            Enumerable.Range((int)'b', (int)'z' - (int)'b' + 1)
                      .Select(c => ((char)c).ToString())
                      .Except(_vowels)
                      .ToArray();
        static readonly Random _random = new Random();
        private static string GenerateName()
        {
            return GenerateConsonant()
                + GenerateVowel()
                + GenerateConsonant()
                + GenerateConsonant()
                + GenerateVowel();
        }
        private static string GenerateVowel()
        {
            return _vowels[_random.Next(_vowels.Length)];
        }
        private static string GenerateConsonant()
        {
            return _consonants[_random.Next(_consonants.Length)];
        }
