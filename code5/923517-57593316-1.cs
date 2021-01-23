    public static class CollectionExtensions {
        public static bool AllElementsEqual<T>(this IEnumerable<T> items) {
            return items.Distinct().Take(2).Count() == 1;
        }
    }
