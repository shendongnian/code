    public class Item : INotifyPropertyChanged
    {
        public string Name { get; set; } // Implement INotifyPropertyChanged
        public string Type { get; set; } // correctly on all of these properties   
        public ObservableCollection<Item> Items { get; set; }
    }
