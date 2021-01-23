    public class Items
    {
        public int RowCount { get; set; }
        public IEnumerable<Item> Rows { get; set; }
    }
    public class Item
    {
        private string ownerId;
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public Person Owner { get; set; }
        public string OwnerId
        {
            get { return this.ownerId; }
            set {
                if (value != this.ownerId)
                {
                    this.Owner = null;
                }
                this.ownerId = value;
            }
        }
    }
 
    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        // other properties
    }
