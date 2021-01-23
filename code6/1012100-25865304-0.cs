    public static class SequenceExt
    {
        public static IEnumerable<int> IndicesOfAllElementsEqualTo<T>
        (
            this IEnumerable<T> sequence, 
            T target
        )   where T: IEquatable<T>
        {
            int index = 0;
            foreach (var item in sequence)
            {
                if (item.Equals(target))
                    yield return index;
                ++index;
            }
        }
    }
