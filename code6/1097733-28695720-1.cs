    public class DetailedItem //as an adapter or proxy object
    {
        private Item item;
        public string ID { get { return item.ID; }}
        public DetailedItem(Item item) { this.item = item; } //constructor
    }
