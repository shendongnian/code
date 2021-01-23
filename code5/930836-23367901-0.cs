    public struct Worker : IComparer
    {
        ...
        public int Compare(object x, object y)
        {
            if (x is Worker && y is Worker)
            {
                return ((Worker)x).FIO.CompareTo(((Worker)y).FIO);
            }
            return 0;
        }
    }
