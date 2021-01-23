    public class NotifyingHashSet<T>
    {
        private HashSet<T> hashSet = new HashSet<T>();
        public bool Add(T item)
        {
            bool added = hashSet.Add(item);
            if(added && ItemAdded != null)
            {
                ItemAdded(this, new NotifyingHashSetEvent<T>(item));
            }
            return added;
        }
        public bool Remove(T item)
        {
            bool removed = hashSet.Remove(item);
            if(removed && ItemRemoved != null)
            {
                ItemRemoved(this, new NotifyingHashSetEvent<T>(item));
            }
            return removed;
        }
        public event EventHandler<NotifyingHashSetEvent<T>> ItemAdded;
        public event EventHandler<NotifyingHashSetEvent<T>> ItemRemoved;
    }
    public class NotifyingHashSetEvent<T> : EventArgs
    {
        public NotifyingHashSetEvent(T item)
        {
            Item = item;
        }
        public T Item { get; set; }
    }
