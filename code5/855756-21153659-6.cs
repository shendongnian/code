    [TestFixture]
    public class WordTests
    {
        [TestCase("HellO", Result = true)]
        [TestCase("heLLo", Result = true)]
        [TestCase("HEllO", Result = false)]
        [TestCase("Hello,", Result = false)]
        public bool HasTwoUppercaseLetters(string word)
        {
            return Word.HasUppercaseLetter(word, 2);
        }
    
        [Test]
        public void HasTwoWordsWithTwoUppercaseLetters()
        {
            // Inpsired by Erik Philips
            Assert.True(
                Word.HowManyWordsHaveUpperCaseLetters("This IS a SEntence", 2) == 2);
        }
    }
