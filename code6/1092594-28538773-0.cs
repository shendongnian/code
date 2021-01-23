    public class InvoiceMembership
    {
        public int ID { get; set; }
        public int SourceId { get; set; }
        [ForeignKey("SourceId")]
        public virtual Source Source { get; set; }
        public virtual InvoiceTemplate InvoiceTemplate { get; set; }
    }
