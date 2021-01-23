    public class ItemViewModel
    {
        public ItemViewModel(string header, string value)
        {
            Header = header;
            Value = value;
        }
    
        public string Header { get; private set; }
    
        public string Value { get; private set; }
    }
    
    public class MainViewModel
    {
        public MainViewModel()
        {
            Items = new[]
            {
                new ItemViewModel("Header 1", "One"),
                new ItemViewModel("Header 2", "Two"),
                new ItemViewModel("Header 3", "Three"),
            };
        }
    
        public IEnumerable<ItemViewModel> Items { get; private set; }
    }
