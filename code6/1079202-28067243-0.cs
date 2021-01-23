    internal class SortedIndex
    {
        public double Comparable { get; set; }
        public int Index { get; set; }
    }
    internal class SortedIndexComparar : IComparer<SortedIndex>
    {
        public int Compare(SortedIndex x, SortedIndex y)
        {
            return x.Comparable.CompareTo(y.Comparable);
        }
    }
