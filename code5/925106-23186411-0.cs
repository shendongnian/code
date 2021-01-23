    public class CustomerAddress : EntityBase<CustomerAddress>
    {
        public int CustomerId { get; set; }
    
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    
        public Address BaseAddress { get; set; }
    }
