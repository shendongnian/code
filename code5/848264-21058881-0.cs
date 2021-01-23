    public class ProductItem
    {
        public int _at { get; set; }
        public string product_id { get; set; }
        public double? quantity { get; set; }
        public int? _delete_at { get; set; }
    }
    
    public class RootObject
    {
        public List<ProductItem> product_items { get; set; }
    }
