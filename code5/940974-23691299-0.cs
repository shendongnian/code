             public static IEnumerable<T> SetPropertyValues<T>(this IEnumerable<T> items, Action<T> action)
            {
                foreach (var item in items)
                {
                    action(item);
                    yield return item;
                }
            }
