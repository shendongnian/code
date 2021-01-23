    [DataContract(IsReference = true)]
        public class Product
        {
            [Key]
            [ForeignKey("ProductType")]
            [DataMember]
            public int ProductTypeId { get; set; }
    
            [DataMember]
            public virtual ProductType ProductType { get; set; }
    
            [DataMember]
            public decimal Quantity { get; set; }
        }
