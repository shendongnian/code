    public class VowelChecker
    {
        private char[] vowels = new [] { 'a', 'e', 'i', 'o', 'u' };
        public bool ContainsVowel(string word)
        {
            foreach (char vowel in vowels)
            {
                // ToLower in case the word is in CAPS
                if (word.ToLower().Contains(vowel))
                {
                    return true;
                }
            }
            return false;
        }
    }
