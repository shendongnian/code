    public class Item
    {
        public string sku;
        public string description;
    
        protected bool Equals(Item other)
        {
            return string.Equals(sku, other.sku) && 
                  string.Equals(description, other.description);
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                return ((sku != null ? sku.GetHashCode() : 0)*397) ^ 
                     (description != null ? description.GetHashCode() : 0);
            }
        }
    }
