    interface IMyRestriction
    {
        IArgumentType1 Property1 { get; set; }
        IArgumentType2 Property2 { get; set; }
    }
    public class MyFactory<TProduct> : IFactory<TProduct>
        where TProduct : class, IMyRestriction, new()
    {
        public TProduct Create()
        {
            var product = new TProduct();
            
            product.Property1 = arg1;
            product.Property2 = arg2;
            return product;
        }
    }
