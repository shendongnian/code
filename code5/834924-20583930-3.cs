    public static class ExtensionMethods
    {
        public static Collection<T> ToCollection<T>(this IEnumerable<T> source)
        {
            Collection<T> sourceCollection = new Collection<T>();
            foreach (T currentSourceInstance in source)
            {
                sourceCollection.Add(currentSourceInstance);
            }
            return sourceCollection;
        }
    } 
