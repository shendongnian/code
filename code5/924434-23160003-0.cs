    public static class Extensions
    {
        public static T Median<T>(this IEnumerable<T> source) where T:IComparable<T>
        {
            if (source == null)
            {
                throw new ArgumentException("source");
            }
            var sortedValues = source.OrderBy(v => v).ToList();
            if (sortedValues.Count == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            var midpoint = (sortedValues.Count/2);
            return sortedValues[midpoint];
        }
    }
