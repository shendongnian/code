    public sealed class ProductEqualityComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product x, Product y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.idProduct == y.idProduct;
        }
        public override int GetHashCode(Product obj)
        {
            return obj.idProduct;
        }
    }
