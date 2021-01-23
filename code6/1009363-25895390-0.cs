            public class VirtualizaingVector<T> : ObservableObject, IObservableVector<object>
            {
        
            public event VectorChangedEventHandler<object> VectorChanged;
        
            private Dictionary<int, T> _items;
        
            private int _count;
            private bool _countCalculated;
        
            private IItemSupplier<T> _itemSuplier;
        
            public VirtualizaingVector(IItemSupplier<T> itemSupplier)
            {
                _itemSuplier = itemSupplier;
                _items = new Dictionary<int, T>();
            }
        
            #region Notifications
        
            private void _notifyVectorChanged(VectorChangedEventArgs args)
            {
                if (VectorChanged != null)
                {
                    VectorChanged(this, args);
                }
            }
        
            private void _notifyReset()
            {
                var args = new VectorChangedEventArgs(CollectionChange.Reset, 0);
                _notifyVectorChanged(args);
            }
        
            private void _notifyReplace(int index)
            {
                var args = new VectorChangedEventArgs(CollectionChange.ItemChanged, (uint)index);
                _notifyVectorChanged(args);
            }
        
            #endregion
        
            #region Private
        
            private void _calculateCount()
            {
                _itemSuplier.GetCount().ContinueWith(task =>
                {
                    lock (this)
                    {
                        _count = task.Result;
                        _countCalculated = true;
                    }
        
                    NotifyPropertyChanged(() => this.Count);
                    _notifyReset();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        
            private void _startRefreshItemAsync(T item)
            {
                var t = new Task(() =>
                {
                    _itemSuplier.RefreshItem(item);
                });
        
                t.Start(TaskScheduler.FromCurrentSynchronizationContext());
            }
        
            private void _startCreateItemAsync(int index)
            {
                var t = new Task<T>(() =>
                {
                    return _itemSuplier.CreateItem(index);
                });
        
                t.ContinueWith(task =>
                {
                    lock (this)
                    {
                        _items[index] = task.Result;
                    }
                    _notifyReplace(index);
                }, TaskScheduler.FromCurrentSynchronizationContext());
        
                t.Start(TaskScheduler.FromCurrentSynchronizationContext());
            }
        
        
            #endregion
        
            public object this[int index]
            {
                get
                {
                    T item = default(T);
                    bool hasItem;
        
                    lock (this)
                    {
                        hasItem = _items.ContainsKey(index);
                        if (hasItem) item = _items[index];
                    }
        
                    if (hasItem)
                    {
                        _startRefreshItemAsync(item);
                    }
                    else
                    {
                        _startCreateItemAsync(index);
                    }
        
                    return item;
                }
                set
                {
                }
            }
        
            public int Count
            {
                get
                {
                    var res = 0;
                    lock (this)
                    {
                        if (_countCalculated)
                        {
                            return res = _count;
                        }
                        else
                        {
                            _calculateCount();
                        }
                    }
        
                    return res;
                }
            }
        
        #region Implemenetation of other IObservableVector<object> interface - not relevant
        ...
        #endregion
    }
        public interface IItemSupplier<T>
        {
            Task<int> GetCount();
        
            T CreateItem(int index);
        
            void RefreshItem(T item);
        }
