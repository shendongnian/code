    [TestFixture]
    public class WordTests
    {
        [TestCase("HellO", Result = true)]
        [TestCase("heLLo", Result = true)]
        [TestCase("HEllO", Result = false)]
        [TestCase("Hello,", Result = false)]
        public bool HasTwoUppercaseLetters(string word)
        {
            return Word.HasUppercaseLetter(word, howMany: 2);
        }
    }
