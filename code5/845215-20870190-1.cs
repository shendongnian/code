    public class ProductExtended
    {
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public int Index { get; set; }
        public ProductExtended(Product product, int index)
        {
            Data1 = product.Data1;
            Data2 = product.Data2;
            Index = index;
        }
    }
