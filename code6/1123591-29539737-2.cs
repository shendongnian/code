    public class VowelChecker
    {
        private char[] vowels = new [] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
        public bool ContainsVowel(string word)
        {
            foreach (char vowel in vowels)
            {
                if (word.Contains(vowel))
                {
                    return true;
                }
            }
            return false;
        }
    }
