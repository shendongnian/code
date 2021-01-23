    public static class ListExtensions
    {
        public static void Replace<T>(this List<T> list, int oldItemIndex, T newItem)
        {
            // many error handling stuff should be here!
            list[oldItemIndex] = newItem;
        }
    }
