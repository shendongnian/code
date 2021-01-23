    public class CountingComparer<T> : Comparer<T>
    {
        public int Count { get; set; }
        IComparer<T> defaultComparer = Comparer<T>.Default;
        public override int Compare(T left, T right)
        {
            this.Count++;
            return defaultComparer.Compare(left, right);
        }
    }
