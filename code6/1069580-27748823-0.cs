    public class SetPair<T>
    {
        private SortedSet<T> first;
        private SortedSet<T> second;
        public SetPair(IComparer<T> firstComparer, IComparer<T> secondComparer)
        {
            first = new SortedSet<T>(firstComparer ?? Comparer<T>.Default);
            second = new SortedSet<T>(secondComparer ?? Comparer<T>.Default);
        }
        public T FirstMin { get { return first.Min; } }
        public T SecondMin { get { return second.Min; } }
        public bool Add(T item)
        {
            return first.Add(item) &&
                second.Add(item);
        }
        public bool Remove(T item)
        {
            return first.Remove(item) &&
                second.Remove(item);
        }
    }
