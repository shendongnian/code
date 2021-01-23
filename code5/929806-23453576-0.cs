    public class MyBindingList<T> : BindingList<T>
    {
        public MyBindingList()
        {
        }
    
        public MyBindingList(IList<T> list)
            : base(list)
        {
        }
        
        // TODO: add other constructors
    
        protected override void RemoveItem(int index)
        {
            // NOTE: we could check if index is valid here before sending the event, this is arguable...
            OnListChanged(new ListChangedEventArgsWithRemovedItem<T>(this[index], index));
    
            // remove item without any duplicate event
            bool b = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            try
            {
                base.RemoveItem(index);
            }
            finally
            {
                RaiseListChangedEvents = b;
            }
        }
    }
    
    public class ListChangedEventArgsWithRemovedItem : ListChangedEventArgs
    {
        public ListChangedEventArgsWithRemovedItem(object item, int index)
            : base(ListChangedType.ItemDeleted, index, index)
        {
            if (item == null)
                throw new ArgumentNullException("item");
                
            Item = item;
        }
    
        public virtual object Item { get; protected set; }
    }
    
    public class ListChangedEventArgsWithRemovedItem<T> : ListChangedEventArgsWithRemovedItem
    {
        public ListChangedEventArgsWithRemovedItem(T item, int index)
            : base(item, index)
        {
        }
    
        public override object Item { get { return (T)base.Item; } protected set { base.Item = value; } }
    }
