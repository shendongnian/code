    class ComplexObj //Maybe should implement INotifyPropertyChanged
    {
        public int Id{get;set;}
        public string SomeProperty{get;set;}
    }
    Dictionary<int, ComplexObj> lookup = new Dictionary<int, ComplexObj>();
    ObservableCollection<ComplexObj> myCollection = new ObservableCollection<ComplexObj>();
