    public class CustomerExtensionValue {
        [Key, ForeignKey("Customer"), Column(Order = 0)]
        public int CustomerId { get; set; }
        [Key, ForeignKey("Extension"), Column(Order = 1)]
        public int ExtensionId { get; set; }
        public Customer Customer { get; set; }
        public CustomerExtension Extension { get; set; }
        [Required]
        public string Value { get; set; }
    }
