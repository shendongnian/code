    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public decimal Price { get; set; }
    }
    
    public class ItemView 
    {
        public ItemView(Item item)
        {
            this.item = item;
        }
        public string DisplayName 
        {
            get
            {
                // TODO: make pretty name
                return this.Item.Name + " (" + this.item.Code + ")";
            }
        }
        public decimal Price
        { 
            get { return this.item.Price; }
            set { this.item.Price = value; }  // TODO: add validation
        }
    
        private Item item;
    }
