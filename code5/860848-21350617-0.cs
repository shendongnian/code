    public abstract class ProductBase
    {
        public string ProductType { get; set; }
    }
    public class ConcreteProduct1 : ProductBase
    {
        public string Foo { get; set; }
    }
    public class ConcreteProduct2 : ProductBase
    {
        public string Bar { get; set; }
    }
