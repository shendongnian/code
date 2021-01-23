    await someTasks.WhenAll()
    namespace System.Linq
    {
        public static class IEnumerableExtensions
        {
            public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> source)
            {
                return Task.WhenAll(source);
            }
        }
    }
