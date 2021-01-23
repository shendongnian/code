    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            //they're both the same instance or they're both null
            if(ReferanceEquals(x, y))
                return true;
            //only one of them is null
            if(x == null || y == null)
                return false;
            return x.Id == y.Id;
        }
        public int GetHashCode(Product prod)
        {
            return prod == null? 0 : prod.Id.GetHashCode();
        }
    }
    big.Except(small, new ProductEqualityComparer())
