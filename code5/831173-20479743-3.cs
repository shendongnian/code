    class SkuAndDescriptionEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            // parse sku and description properly... this assumes the strings are 
            // of the format...  sku:description
            var skux = x.Split(new[] { ':' })[0];
            var skuy = y.Split(new[] { ':' })[0];
            return skux.Equals(skuy);
        }
        public int GetHashCode(string obj)
        {
            // parse sku and description properly... this assumes the strings are 
            // of the format...  sku:description
            var skux = obj.Split(new[] { ':' })[0];
            var hashCode = skux.GetHashCode();
            return hashCode;
        }
