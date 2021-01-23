    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    namespace VJ.Collections
    {
        /// <summary>
        ///     This class adds the ability to refresh the list when any property of
        ///     the objects changes in the list which implements the INotifyPropertyChanged. 
        ///
        /// </summary>
        /// <typeparam name="T">
        ///     The type of elements in the collection.
        /// </typeparam>
        public class ItemsObservableObsrvableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
        {
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (INotifyPropertyChanged item in e.NewItems)
                    { 
                        item.PropertyChanged+=new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (INotifyPropertyChanged item in e.OldItems)
                    { 
                        item.PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
            
                base.OnCollectionChanged(e);
            }
            protected override void ClearItems()
            {
                foreach (INotifyPropertyChanged item in this)
                {
                    item.PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
            
                base.ClearItems();
            }
            private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
    }
