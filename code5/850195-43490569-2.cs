    using System.Collections.Generic;
    
    public class KeyLengthSortedDictionary : SortedDictionary<string, string>
    {
        public int Compare(string x, string y)
            {
                if (x == null) throw new ArgumentNullException(nameof(x));
                if (y == null) throw new ArgumentNullException(nameof(y));
                var lengthComparison = x.Length.CompareTo(y.Length);
                return lengthComparison == 0 ? string.Compare(x, y, StringComparison.Ordinal) : lengthComparison;
            }
    
        public KeyLengthSortedDictionary() : base(new StringLengthComparer()) { }   
    }
