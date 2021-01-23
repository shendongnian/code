    public class WordCountValidator : ValidationAttribute
    {
        readonly int _maximumWordCount;
        public WordCountValidator(int words)
        {
            _maximumWordCount = words;
        }
        // ...
    }
