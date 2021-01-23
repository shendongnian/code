    class TextBase : List<TextSection>
    {
        public IEnumerable<Word> Words
        {
            get { return this.SelectMany(s => s.Words); }
        }
    }
    class TextSection : List<Sentence>
    {
        public IEnumerable<Word> Words
        {
            get { return this.SelectMany(s => s); }
        }
    }
