    public class Item : IComparable<Item>
        {
            public string Name { get; set; }
            public double Value { get; set; }
    
            public int CompareTo(Item other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }
