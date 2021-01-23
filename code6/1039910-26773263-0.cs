    public class NotifyingHashSet<T> : HashSet<T>
    {
        public new void Add(T item)
        {
            OnItemAdded(new NotifyHashSetChanged<T>(item));
            base.Add(item);
        }
        public new void Remove(T item)
        {
            OnItemRemoved(new NotifyHashSetChanged<T>(item));
            base.Remove(item);
        }
        public event EventHandler<NotifyHashSetChanged<T>> ItemAdded;
        public event EventHandler<NotifyHashSetChanged<T>> ItemRemoved;
        protected virtual void OnItemRemoved(NotifyHashSetChanged<T> e)
        {
            if (ItemRemoved != null) ItemRemoved(this, e);
        }
        protected virtual void OnItemAdded(NotifyHashSetChanged<T> e)
        {
            if (ItemAdded != null) ItemAdded(this, e);
        }
    }
    public class NotifyHashSetChanged<T> : EventArgs
    {
        private readonly T _item;
        public NotifyHashSetChanged(T item)
        {
            _item = item;
        }
        public T ChangedItem
        {
            get { return _item; }
        }
    }
