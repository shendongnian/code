    public static class EnumerableExtensions
    {
        public static IEnumerable Append(this IEnumerable source, object o)
        {
            foreach (var x in source)
            {
                yield return x;
            }
            yield return o;
        }
    }
    public class DummyInserter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as IEnumerable;
            if (source == null)    throw new UnsupportedException("DummyInserter converter requires an IEnumerable source");
            return source.Append(new Dummy()).ToArray();
        }
    }
