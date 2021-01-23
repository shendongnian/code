    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.PermutationsImplementation();
        }
        private static IEnumerable<IEnumerable<T>> PermutationsImplementation<T>(this IEnumerable<T> source)
        {
            var sourceCache = source.ToList(); // ToList() makes it about twice as fast
            if (sourceCache.IsSingle())
            {
                return sourceCache.ToIEnumerable();
            }
            return sourceCache
                .Select((a, index1) => PermutationsImplementation(sourceCache.Where((b, index2) => index2 != index1))
                .Select(b => a.PrependImplementation(b)))
                .SelectMany(c => c);
        }
        public static IEnumerable<TSource> Prepend<TSource>(
    this TSource item,
    IEnumerable<TSource> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }
            return PrependImplementation(item, items);
        }
        private static IEnumerable<TSource> PrependImplementation<TSource>(
            this TSource item,
            IEnumerable<TSource> items)
        {
            yield return item;
            foreach (var item2 in items)
            {
                yield return item2;
            }
        }
        public static IEnumerable<TSource> ToIEnumerable<TSource>(this TSource item)
        {
            yield return item;
        }
        public static bool IsSingle<T>(this IEnumerable<T> source)
        {
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                return enumerator.MoveNext() && !enumerator.MoveNext();
            }
        }
        public static IEnumerable<IEnumerable<bool>> AllBooleansCombinations(int count)
        {
            if (count <= 0)
            {
                return Enumerable.Empty<IEnumerable<bool>>();
            }
            if (count == 1)
            {
                return OneBooleanCombination();
            }
            var result = AllBooleansCombinations(count - 1).Select(c => false.Prepend(c))
                            .Concat(
                            AllBooleansCombinations(count - 1).Select(c => true.Prepend(c)));
            return result;
        }
        private static IEnumerable<IEnumerable<bool>> OneBooleanCombination()
        {
            yield return false.ToIEnumerable();
            yield return true.ToIEnumerable();
        }
        public static IEnumerable<IEnumerable<T>> WithMissingItems<T>(this IEnumerable<T> source, bool orderItems = true)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            T[] sourceArray = source.ToArray();
            var booleansCombinations = AllBooleansCombinations(sourceArray.Length);
            var result = booleansCombinations.Select(b => FilterItems(b, sourceArray));
            if (orderItems)
            {
                result = result.Reverse().OrderBy(c => c.Count());
            }
            return result;
        }
        private static IEnumerable<T> FilterItems<T>(this IEnumerable<bool> booleans, T[] items)
        {
            var zippedCombinations = booleans.Zip(items, (boolean, item) => new { boolean, item });
            return zippedCombinations.Where(z => z.boolean).Select(z => z.item);
        }
        public static IEnumerable<IEnumerable<T>> PermutationsWithMissingItems<T>(
    this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var withMissingItems = source.WithMissingItems();
            return withMissingItems.SelectMany(m => m.Permutations());
        }
    }
