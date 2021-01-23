    public static class CombinatorialExtension
    {
        public static IEnumerable<IList<TSource>> GetCombinations<TSource>(
            this IList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return GetCombinationsImpl<TSource>(source);
        }
    
        private static IEnumerable<IList<TSource>> GetCombinationsImpl<TSource>(
            this IList<TSource> list)
        {
            return Permutations(list, list.Count);
        }
    
        private static void ShiftRight<TSource>(IList<TSource> list, int cardinality)
        {
            var lastElement = list[cardinality - 1];
            list.RemoveAt(cardinality - 1);
            list.Insert(0, lastElement);
        }
    
        private static IEnumerable<IList<TSource>> Permutations<TSource>(IList<TSource> list, int cardinality)
        {
            if (cardinality == 1)
            {
                yield return list;
            }
            else
            {
                for (int i = 0; i < cardinality; i++)
                {
                    foreach (var perm in Permutations(list, cardinality - 1))
                        yield return perm;
                    ShiftRight(list, cardinality);
                }
            }
        }
    }
