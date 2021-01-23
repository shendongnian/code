    // Only define properties that are part of the WCF message
    public interface IProductXfer
    {
        int ProductID { get; }
        string ProductName { get; }
        decimal QuantityPerUnit { get; }
        decimal UnitPrice { get; }
        bool Discontinued { get; }
    }
    
    public class ProductEntity : IProductXfer
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        // This is one property that must be transformed ->
        public decimal? QuantityPerUnit { get; set; }
        decimal IProductXfer.QuantityPerUnit { get { return (decimal)(QuantityPerUnit ?? 0m); } }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        // These properties are not sent in the WCF message    
        public BitMap Image { get; set; }
        public decimal QuantityOnHand { get; set; }
    
    }
