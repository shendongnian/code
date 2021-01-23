    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        // other properties ...  
     
        public virtual ProductBinaryData ProductBinaryData { get; set; }
    }
     
    public class ProductBinaryData
    {
        [Key]
        public int ProductID { get; set; }
    
        public byte[] File1 { get; set; }
        public byte[] File2 { get; set; }
        public byte[] File3 { get; set; }
    }
