       public static void ForEachIndex<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            int index = 0;
            foreach (T curr in collection)
            {
                action(curr, index);
                index++;
             }
        }
