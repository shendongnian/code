    public class Item : INotifyPropertyChanged // implement this interface properly
    {
        public string Name { get; set; }
        public ObservableCollection<SomeType> ItemCollection { get; set; }
    }
