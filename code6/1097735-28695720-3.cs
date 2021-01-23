    public class DetailedItem //as an adapter or proxy object
    {
        private Item item;
        public string ID { get { return item.ID; }}
        public string Name { get { return item.Name;}}
        public DetailedItem(Item item) { this.item = item; } //constructor
    }
