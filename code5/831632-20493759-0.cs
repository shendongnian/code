    public class ListwAddRemove<T> : Collection<T>
    {
        public ListwAddRemove<T>()
        {
        }
        public ListwAddRemove<T>(IList<T> list) : base(list)
        {
        }
        ... implementation of overrides for InsertItem, SetItem, RemoveItem ...
    }
