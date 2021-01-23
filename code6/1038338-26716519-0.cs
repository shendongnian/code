    public class Transaction2
    {
        public int transactionId { get; set; }    
        public List<Item> itemList = new List<Item> { };    
        public class Item
        {
            public string itemName { get; set; }    
            public int quantity { get; set; }
        }
    }
    ....
    var list = new List<Transaction>
    {
        new Transaction { transactionId = 1, itemName = "foo", quantity = 5 },
        new Transaction { transactionId = 1, itemName = "bar", quantity = 5 },
        new Transaction { transactionId = 2, itemName = "example", quantity = 5 },
    };
    
    var list2 = list
        .GroupBy(z => z.transactionId)
        .Select(z => new Transaction2
            {
                transactionId = z.Key,
                itemList = z
                    .Select(z2 => new Transaction2.Item 
                    {
                        itemName = z2.itemName, 
                        quantity = z2.quantity 
                    })
                    .ToList()
            })
        .ToList();
