    public static class CustomEnumerator
    {
        private static int _counter = 0;
        private static IEnumerator enumerator;
        public static IEnumerable<T> GetRecords<T>(this IEnumerable<T> source)
        {
            if (enumerator == null) enumerator = source.GetEnumerator();
            if (_counter == 0)
            {
                enumerator.MoveNext();
                _counter++;
                yield return (T)enumerator.Current;
            }
            else
            {
                while (enumerator.MoveNext())
                {
                    yield return (T)enumerator.Current;
                }
                _counter = 0;
                enumerator = null;
            }
        } 
    }
