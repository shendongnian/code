    public class MyCollection : ObservableCollection<MyItem> { }
    public class MyItem
    {
        // NOTE: these must be get/set properties in order for binding to work
        public string Text { get; set; }
        public int Anzhal { get; set; }
    }
