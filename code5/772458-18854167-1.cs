    public class EmployeeKeyComparer : IComparer<Tuple<int, string>>
    {
        public int Compare(Tuple<int, string> x, Tuple<int, string> y)
        {
            if (x.First == y.First)
                return StringComparer.Ordinal.Compare(x.Second, y.Second);
            else
                return x.First.CompareTo(y.First);
        }
    }
