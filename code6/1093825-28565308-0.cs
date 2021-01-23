    public class Product : IEquatable<Product> 
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
    
        public bool Equals(Product product)
        {
            if (product == null)
            {
                return false;
            }
    
            return (Id == product.Id) && (Quantity == product.Quantity);
        }
    }
