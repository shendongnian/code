    public class Item {
        public string Name { get; set; }
        public double Price { get; set; }
        public Item()
        {
        }
        public Item(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
    public class ItemOrder
    {
        public Item Product { get; set; }
        public int Quantity { get; set; }
        
        public ItemOrder()
        {
        }
        public ItemOrder(Item product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
    void Main()
    {
        List<Item> inventory = new List<Item>();
        Item pancakes = new Item("Pancakes", 6.25);
        inventory.Add(pancakes);
        List<ItemOrder> currentCart = new List<ItemOrder>();
        ItemOrder item = new ItemOrder(inventory[0], 2); // stand in values for userInput and quantity
        currentCart.Add(item);
        foreach (ItemOrder i in currentCart)
            {
                double currentPrice = i.Product.Price*i.Quantity;
                Console.WriteLine("(" + (currentCart.IndexOf(i) + 1) + ") : " + i.Product.Name + "\t        " + currentPrice);
            }
    }
