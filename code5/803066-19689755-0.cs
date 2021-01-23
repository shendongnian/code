    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Offer Offer { get; set; }
    }
    public class Offer
    {
        [ForeignKey("Product")]
        public int ID { get; set; }
        
        [Required]
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal OfferPrice { get; set; }
        public Product Product { get; set; }
    }
