    internal class BarComparer : IComparer<Bar>
    {
        public static BarComparer Default = new BarComparer();
        public int Compare(Bar x, Bar y)
        {
            if (ReferenceEquals(x, y))
                return 0;
            if (ReferenceEquals(x, null))
                return -1;
            if (ReferenceEquals(y, null))
                return 1;
            return x.Volume.CompareTo(y.Volume);
        }
    }
