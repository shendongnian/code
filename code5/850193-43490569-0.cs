    using System.Collections.Generic;
    
    public class KeyLengthSortedDictionary : SortedDictionary<string, string>
    {
        private class StringLengthComparer : IComparer<string>
        {
            public int Compare(string x, string y) => (x?.Length ?? 0) - (y?.Length ?? 0);
        }
    
        public KeyLengthSortedDictionary() : base(new StringLengthComparer()) { }   
    }
