    public class MyCollection<T> : System.Collections.ObjectModel.ObservableCollection<T>
    {
        public event CollectionChangeEventHandler RealCollectionChanged;
    
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add && e.NewItems.Count > 0)
            {
                this.OnRealCollectionChanged(e.NewItems[0]);
            }
        }
    
        protected virtual void OnRealCollectionChanged(object element)
        {
            if (this.RealCollectionChanged != null)
            {
                this.RealCollectionChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Add, element));
            }
        }
    }
