    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public int PaymentTransactionId { get; set; }
        public string CustomerId { get; set; }
        public int ChildId { get; set; }
        public DateTime PickUpDate { get; set; }
        public PickUpTime PickUpTime { get; set; }
        public string Notes { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public OrderStatus Status { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ApplicationUser Customer { get; set; }
        public virtual Child Child { get; set; }
        public virtual PaymentTransaction PaymentTransaction { get; set; }
        public virtual PromotionCode PromotionCode { get; set; }
    }
