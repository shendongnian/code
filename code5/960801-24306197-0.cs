    class ReverseComparer : IComparer<string> {
        public int Compare(string x, string y) {
            return -x.CompareTo(y);
        }
    }
    var testIds = new SortedList<string,object>(new ReverseComparer());
