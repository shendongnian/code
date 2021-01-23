    public class Product : IEquatable
    {
        public string ProductName;
        public bool Equals( object o )
        {
            Product other = o as Product;
            if( other == null ) 
                 return false;
            return ProductName == other.ProductName;
        }
    }
