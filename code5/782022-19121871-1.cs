    public class SortedList<T> : List<T>, ISortableObject
        where T : ISortableObject
    {
        public override int compare(ISortableObject obj);
    }
