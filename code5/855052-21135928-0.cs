    class Program
    {
        static void Main(string[] args)
        {
            List<ShoppingBasket> bag = new List<ShoppingBasket>();
    
            bag.Add(new ShoppingBasket("Bread", 1.20M, 1));
            bag.Add(new ShoppingBasket("Bread", 2.40M, 2));
            bag.Add(new ShoppingBasket("Bread", 3.60M, 3));
    
            bag.Add(new ShoppingBasket("Eggs", 1.50M, 1));
            bag.Add(new ShoppingBasket("Eggs", 3.000M, 2));
    
    
            var result = from x in bag
                        group x by x.Product into g
                       select new ShoppingBasket(g.Key, g.Max(x => x.Price),
                       g.Max(x => x.Quantity));
        }
    }
    public class ShoppingBasket
    {
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    
        public ShoppingBasket(string product, decimal price, int quantity)
        {
            this.Product = product;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
