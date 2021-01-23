    class SomeClass
    {
        private static ObservableCollection<MyData> myObservableCollection = new ObservableCollection<MyData>();
        public static ObservableCollection<MyData> MyObservableCollection
        {
             get { return SomeClass.myObservableCollection; }
             set { SomeClass.myObservableCollection = value; }
        }         
    }
