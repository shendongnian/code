    public class ExtendedBindingList<T> : BindingList<T>
    {
        public T LastRemovedItem { get; private set; }
        protected override void RemoveItem(int index)
        {
            LastRemovedItem = base[index];
            base.RemoveItem(index);            
        }
    }
