    public class ItemsObservableObsrvableCollection<T> : ObservableCollection<T>
    {
        public override event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;
        public new void Add(T item)
        {
            base.Add(item);
            INotifyPropertyChanged t = item as INotifyPropertyChanged;
            if (t != null)
            {
                t.PropertyChanged +=new PropertyChangedEventHandler(item_PropertyChanged);
            }
        }
        public new void Remove(T item)
        {
            base.Remove(item);
            INotifyPropertyChanged t = item as INotifyPropertyChanged;
            if (t != null)
            {
                t.PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
            }
        }
        public new void Clear()
        {
            foreach (var item in Items)
            {
                INotifyPropertyChanged t = item as INotifyPropertyChanged;
                if (t != null)
                {
                    t.PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                }   
            }
            base.Clear();
        }
        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.CollectionChanged(sender, null);
        }
    }
