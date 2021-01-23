    static class ArrayExtensions
    {
        public static void ForEach<T>(this T[] array, Func<T,T> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = action(array[i]);
            }
        }
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                action(array[i]);
            }
        }   
    }
    //usage
    foo.ForEach(x => x/2)
