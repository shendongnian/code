    var observableCollection = new ObservableCollection<string>();
    observableCollection.CollectionChanged += (s, e) => 
        {
            doStuff();
        }
 
    class A
    {
         public static ObservableCollection<A> list = new ObservableCollection<A>();
    }
    class B
    {
        public void StartListening()
        {
            A.list.CollectionChanged += collectionSizeChanged;
        }
    }
