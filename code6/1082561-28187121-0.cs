    public class ProductDetailsComparer : IComparer<ProductDetails>
    {
        private bool _compareMinPrice;
        public ProductDetailsComparer(bool compareMinPrice)
        {
            _compareMinPrice = compareMinPrice;
        }
        public int Compare(ProductDetails x, ProductDetails y)
        {
            var left = _compareMinPrice ? x.priceCl.Min(p => p.price) : x.priceCl.Max(p => p.price);
            var right = _compareMinPrice ? y.priceCl.Min(p => p.price) : y.priceCl.Max(p => p.price);
            return left.CompareTo(right);
        }
    }
