    public static class EnumerableExtensions
    {
        public static IEnumerable<TValue []> Permutations<TKey, TValue>(this IEnumerable<TKey> keys, Func<TKey, IEnumerable<TValue>> selector)
        {
            var keyArray = keys.ToArray();
            if (keyArray.Length < 1)
                yield break;
            TValue [] values = new TValue[keyArray.Length];
            foreach (var array in Permutations(keyArray, 0, selector, values))
                yield return array;
        }
        static IEnumerable<TValue []> Permutations<TKey, TValue>(TKey [] keys, int index, Func<TKey, IEnumerable<TValue>> selector, TValue [] values)
        {
            Debug.Assert(keys.Length == values.Length);
            var key = keys[index];
            foreach (var value in selector(key))
            {
                values[index] = value;
                if (index < keys.Length - 1)
                {
                    foreach (var array in Permutations(keys, index+1, selector, values))
                        yield return array;
                }
                else
                {
                    yield return values.ToArray(); // Clone the array;
                }
            }
        }
    }
