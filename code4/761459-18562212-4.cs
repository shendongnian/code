    public struct WordLocation
    {
        public WordLocation(string fileName, int lineNumber, int wordIndex)
        {
            FileName = fileName;
            LineNumber = lineNumber;
            WordIndex = wordIndex;
        }
        public readonly string FileName; // file containing the word.
        public readonly int LineNumber;  // line within the file.
        public readonly int WordIndex;   // index within the line.
    }
    public struct WordOccurrences
    {
        private WordOccurrences(int nOccurrences, WordLocation[] locations)
        {
            NumberOfOccurrences = nOccurrences;
            Locations = locations;
        }
        public static readonly WordOccurrences None = new WordOccurrences(0, new WordLocation[0]);
        public static WordOccurrences FirstOccurrence(string fileName, int lineNumber, int wordIndex)
        {
            return new WordOccurrences(1, new [] { new WordLocation(fileName, lineNumber, wordIndex) });
        }
        public WordOccurances AddOccurrence(string fileName, int lineNumber, int wordIndex)
        {
            return new WordOccurrences(
                NumberOfOccurrences + 1, 
                Locations
                    .Concat(
                        new [] { new WordLocation(fileName, lineNumber, wordIndex) })
                    .ToArray());
        }
        public readonly int NumberOfOccurrences;
        public readonly WordLocation[] Locations;
    }
    public interface IWordIndexBuilder
    {
        void AddWordOccurrence(string word, string fileName, int lineNumber, int wordIndex);
        IWordIndex Build();
    }
    public interface IWordIndex
    {
        WordOccurrences Find(string word);
    }
    public static class BuilderExtensions
    {
        public static IWordIndex BuildIndexFromFiles(this IWordIndexBuilder builder, IEnumerable<FileInfo> wordFiles)
        {
            var wordSeparators = new char[] {',', ' ', '\t', ';' /* etc */ };
            foreach (var file in wordFiles)
            {
                var lineNumber = 1;
                using (var reader = file.OpenText())
                {
                    while (!reader.EndOfStream)
                    {
                        var words = reader
                             .ReadLine() 
                             .Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries)
                             .Select(f => f.Trim());
                        var wordIndex = 1;
                        foreach (var word in words)
                            builder.AddWordOccurrence(word, file.FullName, lineNumber, wordIndex++);
                        lineNumber++;
                    }
                }
            }
            return builder.Build();
        }
    }
