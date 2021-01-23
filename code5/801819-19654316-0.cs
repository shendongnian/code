    public class Union<T1, T2>
    {
        private readonly T1 _value1;
        private readonly T2 _value2;
        public Union(T1 value)
        {
            _value1 = value;
        }
        public Union(T2 value)
        {
            _value2 = value;
        }
        public T1 Case1
        {
            get { return _value1; }
        }
        public T2 Case2
        {
            get { return _value2; }
        }
    }
    var prod = vid.HasValue ? 
        new Union<ProductVariant, Product>(CatalogRepository.GetProductDetailByProductId(pid.Value, vid)) :
        new Union<ProductVariant, Product>(CatalogRepository.GetProductDetailByProductId(pid.Value));
