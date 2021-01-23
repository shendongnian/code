    public class Fruit : IComparer<Fruit>, IComparable<Fruit>
        {
            public Fruit(string name, double price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }
    
            protected int Quantity { get; set; }
    
            protected double Price { get; set; }
    
            protected string Name { get; set; }
    
            public int CompareTo(Fruit other)
            {
                if (Quantity < other.Quantity) return 1;
                if (Quantity > other.Quantity) return -1;
                return 0;
            }
    
            public override string ToString()
            {
                return string.Format("{0} {1} {2}", Name, Price, Quantity);
            }
    
            public int Compare(Fruit x, Fruit y)
            {
                if (x.Quantity > y.Quantity) return 1;
                if (x.Quantity < y.Quantity) return -1;
                return 0;
            }
        }
