    public class Item
    {
        public string ItemName { get; set; }
    }
    ObservableCollection<Item> _ItemsList = new ObservableCollection<Item>();
    public ObservableCollection<Item> ItemsList 
    {
        get
        {
            return _ItemsList ;
        }
        set
        {
            _ItemsList = value;
            OnPropertyChanged();
        }
    }
