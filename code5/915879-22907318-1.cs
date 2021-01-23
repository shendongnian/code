    public class Product
    {
        public Product()
        {
            ItemsCollection = new ObservableCollection<Item>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Item> ItemsCollection { get; set; }
    }
    public class Item
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
    }
