    public class BinarySearchComparer : IComparer<Tuple<int, int>>
    {
        public int Compare(Tuple<int, int> f1, Tuple<int, int> f2)
        {
            return EqualityComparer<int>.Default.Compare(f1.Item1, f2.Item1);
        }
    }
