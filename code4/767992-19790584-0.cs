    public class NotifyObservableCollection<TItem> : ObservableCollection<TItem>
        where TItem : class , INotifyPropertyChanged, new()
    {
        #region Fields
        private Action _itemPropertyChanged;
        #endregion
        #region Constructor
        public NotifyObservableCollection(Action itemPropertyChanged)
        {
            _itemPropertyChanged = itemPropertyChanged;
        }
        #endregion
        #region Methods
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var notifyItem = item as INotifyPropertyChanged;
                    if (notifyItem != null)
                    {
                        notifyItem.PropertyChanged += ItemPropertyChanged;
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    var notifyItem = item as INotifyPropertyChanged;
                    if (notifyItem != null)
                    {
                        notifyItem.PropertyChanged -= ItemPropertyChanged;
                    }
                }
            }
            base.OnCollectionChanged(e);
        }
        #endregion
        #region Private Methods
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(_itemPropertyChanged!=null)
            {
                _itemPropertyChanged();
            }
        }
        #endregion
    }
