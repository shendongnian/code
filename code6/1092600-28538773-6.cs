    public class InvoiceMembership
    {
        public int ID { get; set; }
        public int SourceId { get; set; }
        [ForeignKey("SourceId")]
        public virtual Source Source { get; set; }
        public virtual InvoiceTemplate InvoiceTemplate { get; set; }
        static public InvoiceTemplate ReadCurrentTemplate(int sourceId)
        {
            using (var context = new MedicalContext())
                return context.InvoiceMemberships
                              .Where(m => m.SourceId == sourceId)
                              .Where(m => m.EndDate == null)
                              .Select(m => m.InvoiceTemplate)
                              .FirstOrDefault();
        }
    }
