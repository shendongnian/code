    public static class ListExtensions
    {
        public static void Replace<T>(this List<T> list, Predicate<T> oldItemSelector , T newItem)
        {
            //check for different situations here and throw exception
            //if list contains multiple items that match the predicate
            //or check for nullability of list and etc ...
            var oldItemIndex = list.FindIndex(oldItemSelector);
            list[oldItemIndex] = newItem;
        }
    }
