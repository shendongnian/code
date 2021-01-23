    public class Item
    {
        public string Name { get; set; }
        public string Category { get; set; }
 
        public Item(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
    public class Items : GroupedObservableCollection<Item, string>
    {
        public Items(IEnumerable<Item> items)
            : base(items, item => item.Category) { }
    }
    public class ViewModel
    {
        public IEnumerable<Item> Source { get; private set; }
        public ViewModel()
        {
            Source = new Items(new Item[] {
                new Item("Apples", "Fruits"),
                new Item("Carrots", "Vegetables"),
                new Item("Bananas", "Fruits"),
                new Item("Lettuce", "Vegetables"),
                new Item("Oranges", "Fruits")
            });
        }
    }
