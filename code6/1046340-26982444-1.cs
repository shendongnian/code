    public class SequenceComparer<T> : IComparer<IEnumerable<T>>
    {
        private IComparer<T> comparer;
        public SequenceComparer(IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
        }
        public int Compare(IEnumerable<T> x, IEnumerable<T> y)
        {
            using (var first = x.GetEnumerator())
            using (var second = y.GetEnumerator())
            {
                while (true)
                {
                    var hasFirst = first.MoveNext();
                    var hasSecond = second.MoveNext();
                    if (hasFirst && !hasSecond)
                        return 1;
                    if (hasSecond && !hasFirst)
                        return -1;
                    if (!hasFirst && !hasSecond)
                        return 0;
                    var comparison = comparer.Compare(first.Current, second.Current);
                    if (comparison != 0)
                        return comparison;
                }
            }
        }
    }
