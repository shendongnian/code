    public static MinAndMax<T> MinAndMax<T>(this IEnumerable<T> source)
        where T : IComparable<T>
    {
        Ensure.NotNullOrEmpty(source, nameof(source));
        using (var enumerator = source.GetEnumerator())
        {
            if (enumerator.MoveNext())
            {
                var min = enumerator.Current;
                var max = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    if (Comparer<T>.Default.Compare(enumerator.Current, min) < 0)
                    {
                        min = enumerator.Current;
                    }
                    if (Comparer<T>.Default.Compare(enumerator.Current, max) > 0)
                    {
                        max = enumerator.Current;
                    }
                }
                return new MinAndMax<T>(min, max);
            }
            throw new InvalidOperationException("Sequence contains no elements.");
        }
    }
    public struct MinAndMax<T>
        where T : IComparable<T>
    {
        public MinAndMax(T min, T max)
        {
            this.Min = min;
            this.Max = max;
        }
        public T Min { get; }
        public T Max { get; }
    }
