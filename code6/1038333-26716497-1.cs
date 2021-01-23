    public class Transaction
    {
        public int transactionId { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
    }
    public class TransactionGroup
    {
        public int transactionId { get; set; }
        public List<Item> itemList = new List<Item> { };
    }
    public class Item
    {
        public string itemName { get; set; }
        public int quantity { get; set; }
    }
