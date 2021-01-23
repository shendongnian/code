        public static bool IsEquivalent<T, TU>(this ICollection<T> collection, ICollection<TU> sourceCollection, Func<T, TU, bool> predicate) where T : class
        {
            var copyCollection = collection.Clone();
            if (copyCollection.Count == 0 && !sourceCollection.Any()) return true;
            foreach (var source in sourceCollection)
            {
                var element = copyCollection.FirstOrDefault(x => predicate(x, source));
                if (element == null) return false;
                copyCollection.Remove(element);
            }
            return !copyCollection.Any();
        }
        public static ICollection<T> Clone<T>(this ICollection<T> listToClone)
        {
            var array = new T[listToClone.Count];
            listToClone.CopyTo(array, 0);
            return array.ToList();
        }
