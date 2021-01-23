    public class WordCount : IComparable<WordCount>
    {
        public string Word { get; set; }
        public int CharCount { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            WordCount wc = obj as WordCount;
            return wc == null ? false : Equals(wc);
        }
        public int CompareTo(WordCount wc)
        {
            //Descending
            return wc == null ? 1 : wc.CharCount.CompareTo(CharCount);
            //Ascending
            //return wc == null ? 1 : CharCount.CompareTo(wc.CharCount);
        }
        public override int GetHashCode()
        {
            return CharCount;
        }
        public bool Equals(WordCount wc)
        {
            return wc == null ? false : CharCount.Equals(wc.CharCount);
        }
    }
    //Usage:
    List<WordCount> counts = new List<WordCount>();
    //Fill the list
    counts.Sort();
