    public class MyClass
    {
        ObservableCollection<Stuff> oc;
        //Assumes oc is never null.
        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { oc.CollectionChanged += value; }
            remove { oc.CollectionChanged -= value; }
        }
    }
