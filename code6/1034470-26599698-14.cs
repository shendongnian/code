    public class WordInfo
    {
        public WordInfo(string word, int firstLineNumber)
        {
            this.Word = word;
            this.WordCount = 1;
            this.LineNumbers = new List<int>() { firstLineNumber };
        }
        public string Word { get; set; }
        public int WordCount { get; set; }
        public List<int> LineNumbers { get; set; }
    }
