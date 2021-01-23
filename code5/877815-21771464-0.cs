    public class NotifyCollection
    {
        private readonly ObservableCollection<Notify> collection;
        public NotifyCollection()
        {
            collection = new ObservableCollection<Notify>();
            collection.CollectionChanged += collection_CollectionChanged;
        }
        private void collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if ((e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace) && e.OldItems != null)
            {
                foreach (var oldItem in e.OldItems)
                {
                    var item = (Notify)oldItem;
                    try
                    {
                        item.PropertyChanged -= notify_changes;
                    }
                    catch { }
                }
            }
            if((e.Action==NotifyCollectionChangedAction.Add || e.Action==NotifyCollectionChangedAction.Replace) && e.NewItems!=null)
            {
                foreach(var newItem in e.NewItems)
                {
                    var item = (Notify)newItem;
                    item.PropertyChanged += notify_changes;
                }
            }
            notify_changes(null, null);
        }
        private void notify_changes(object sender, PropertyChangedEventArgs e)
        {
            //notify code here
        }
        public ObservableCollection<Notify> Collection
        {
            get
            {
                return collection;
            }
        }
    }
