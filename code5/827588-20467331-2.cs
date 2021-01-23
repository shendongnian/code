    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    namespace VJ.Collections
    {
        /// <summary>
        ///     This class adds the ability to refresh the list when any property of
        ///     the objects which implements the INotifyPropertyChanged in the list changes. 
        ///
        /// </summary>
        /// <typeparam name="T">
        ///     The type of elements in the collection.
        /// </typeparam>
        public class ItemsObservableObsrvableCollection<T> : ObservableCollection<T>
        {
            public new void Add(T item)
            {
                INotifyPropertyChanged obj = item as INotifyPropertyChanged;
                if (obj != null)
                {
                    obj.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                }
                base.Add(item);
            }
            public new void Remove(T item)
            {
                INotifyPropertyChanged obj = item as INotifyPropertyChanged;
                if (obj != null)
                {
                    obj.PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
                base.Remove(item);
            }
            public new void Clear()
            {
                foreach (var item in Items)
                {
                    INotifyPropertyChanged obj = item as INotifyPropertyChanged;
                    if (obj != null)
                    {
                        obj.PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
                base.Clear();
            }
            private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
    }
