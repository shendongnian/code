    public class DictionaryIndexBuilder : IIndexBuilder
    {
        private Dictionary<string, WordOccurrences> _dict;
        private class DictionaryIndex : IWordIndex 
        {
            private readonly Dictionary<string, WordOccurrences> _dict;
            public DictionaryIndex(Dictionary<string, WordOccurrences> dict)
            {
                _dict = dict;
            }
            public WordOccurrences Find(string word)
            {
               WordOccurrences found;
               if (_dict.TryGetValue(word, out found);
                   return found;
               return WordOccurrences.None;
            }
        }
        public DictionaryIndexBuilder(IEqualityComparer<string> comparer)
        {
            _dict = new Dictionary<string, WordOccurrences>(comparer);
        }
        public void AddWordOccurrence(string word, string fileName, int lineNumber, int wordIndex)
        {
            WordOccurrences current;
            if (!_dict.TryGetValue(word, out current))
                _dict[word] = WordOccurrences.FirstOccurrence(fileName, lineNumber, wordIndex);
            else
                _dict[word] = current.AddOccurrence(fileName, lineNumber, wordIndex);
        }
        public IWordIndex Build()
        {
            var dict = _dict;
            _dict = null;
            return new DictionaryIndex(dict);
        }
    }
