        public static class Extensions
        {
            public static void ForeEach<T>(this IEnumerable<T> instance, Action<T> action)
            {
                foreach (T item in instance)
                {
                   action(item);
                }
           }
        }
