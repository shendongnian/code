    public class MainViewModel
    {
      public ObservableCollection<Item> Items { get; private set; }
      public MainViewModel() { Items = new ObservableCollection<Item>(); }
    }
