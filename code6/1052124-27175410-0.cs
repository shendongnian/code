    public class Item : IEqualityComparer<Item>
    {
    	public string Value1 { get; set; }
    	public string Value2 { get; set; }
    
        public bool Equals(Item x, Item y)
        {
            return x.Valie1 == y.Value1 && x.Value2 != y.Value2;
        }
    
        public int GetHashCode(string obj)
        {
            // implement
        }
    }
