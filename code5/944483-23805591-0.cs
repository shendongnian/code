    public static class BindingListExtension
    {
        public static void AddFirst<T>(this BindingList<T> list, T item)
        {
            list.Insert(0, item);
        }
        public static void RemoveLast<T>(this BindingList<T> list)
        {
            list.RemoveAt(list.Count - 1);
        }
    }
