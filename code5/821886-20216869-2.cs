    public class SortStringLength : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length == y.Length)
                return String.CompareOrdinal(x, y);
            if (x.Length > y.Length)
                return 1;
            return -1;
        }
    }
