    public class Range<T>
        where T : IComparable
    {
        public Range(T from, T to)
        {
            if (from.CompareTo(to) > 0)
                throw new ArgumentException("From should not be greater than To");
            From = from;
            To = to;
        }
        public T From { get; private set; }
        public T To { get; private set; }
        public bool Contains(T value)
        {
            return value.CompareTo(From) >= 0 && value.CompareTo(To) <= 0;
        }
        // other methods like Intersects etc
    }
