    public class ChartGroupCollection : ObservableCollection<ChartGroup>
    {
        public int SomeVariable { get; set; }
        public ChartGroupCollection()
        {
            CollectionChanged += ChartGroupCollection_CollectionChanged;
        }
        void ChartGroupCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach(ChartGroup item in e.OldItems)
            {
                item.PropertyChanged -= item_PropertyChanged;
            }
            foreach (ChartGroup item in e.NewItems)
            {
                item.PropertyChanged += item_PropertyChanged;
            }
        }
        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MethodIWantToRun(); 
        }
        private void MethodIWantToRun()
        {
            SomeVariable++;
        }
    }
    public class ChartGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        int _myProperty;
        public int MyProperty
        {
            set {
                _myProperty = value;
                NotifyPropertyChanged();
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
            }
        }
    }
