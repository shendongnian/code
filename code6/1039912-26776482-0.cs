    public class NotifyingHashSet<T> : HashSet<T>, ICollection<T> {
    
      new public void Add(T item) {
        ((ICollection<T>) this).Add(item);
      }
    
      new public Boolean Remove(T item) {
        return ((ICollection<T>) this).Remove(item);
      }
    
      void ICollection<T>.Add(T item) {
        var added = base.Add(item);
        if (added)
          OnItemAdded(new NotifyHashSetEventArgs<T>(item));
      }
    
      Boolean ICollection<T>.Remove(T item) {
        var removed = base.Remove(item);
        if (removed)
          OnItemRemoved(new NotifyHashSetEventArgs<T>(item));
        return removed;
      }
    
      public event EventHandler<NotifyHashSetEventArgs<T>> ItemAdded;
    
      public event EventHandler<NotifyHashSetEventArgs<T>> ItemRemoved;
    
      protected virtual void OnItemRemoved(NotifyHashSetEventArgs<T> e) {
        var handler = ItemRemoved;
        if (handler != null)
          ItemRemoved(this, e);
      }
    
      protected virtual void OnItemAdded(NotifyHashSetEventArgs<T> e) {
        var handler = ItemAdded;
        if (handler != null)
          ItemAdded(this, e);
      }
    
    }
    
    public class NotifyHashSetEventArgs<T> : EventArgs {
    
      public NotifyHashSetEventArgs(T item) {
        Item = item;
      }
    
      public T Item { get; private set; }
    
    }
