    public partial class Quatation
    {
        public int QuatationId { get; set; } 
        public int FirmId { get; set; } 
        public int ItemId { get; set; } 
        public double Quantity { get; set; } 
        public decimal Price { get; set; }
        public DateTime? Dated { get; set; }
        public int IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyBy { get; set; }
        public virtual Firm Firm { get; set; }
        public virtual Item Item { get; set; }
    }
