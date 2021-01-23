    internal static class ExtensionMethods
    {
        public static IEnumerable<T> SelectManyRecusive<T>(this IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {
                var castEnumerable = item as IEnumerable;
                if (castEnumerable != null 
                    && ((typeof(T) != typeof(string)) || !(castEnumerable is string))) //Don't split string to char if string is our target
                {
                    foreach (var inner in SelectManyRecusive<T>(castEnumerable))
                    {
                        yield return inner;
                    }
                }
                else
                {
                    if (item is T)
                    {
                        yield return (T)item;
                    }
                }
            }
        }
    }
