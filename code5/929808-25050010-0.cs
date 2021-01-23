        public void X()
        {
            ObservableCollection<object> oc = new ObservableCollection<object>();
            BindingList<object> bl = new BindingList<object>(oc);
            oc.CollectionChanged += oc_CollectionChanged;
            bl.Add(new object());
            bl.RemoveAt(0);
        }
        void oc_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (object o in e.OldItems)
                {
                    //o was deleted
                }
            }
        }
