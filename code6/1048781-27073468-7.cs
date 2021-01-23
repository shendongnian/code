    Or, roll your own proxy wrapper:
        public sealed class ProductAddWrapper
        {
            public ProductAddWrapper()
            {
            }
            public ProductAddWrapper(ProductAdd product)
            {
                this.ProductAdd = product;
            }
            public ProductAdd ProductAdd { get; set; }
            public static implicit operator ProductAdd(ProductAddWrapper wrapper) { return wrapper.ProductAdd; }
            public static implicit operator ProductAddWrapper(ProductAdd product) { return new ProductAddWrapper(product); }
        }
