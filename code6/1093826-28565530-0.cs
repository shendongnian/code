    class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.Id == y.Id && x.Quantity == y.Quantity;
        }
        public int GetHashCode(Product product)
        {
            if (Object.ReferenceEquals(product, null)) return 0;
            return product.Id.GetHashCode() ^ product.Quantity.GetHashCode();
        }
    }
