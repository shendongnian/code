    public class Source
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public InvoiceTemplate CurrentTemplate
        { 
            get
            {
                return InvoiceMemberships
                       .Where(i = i.EndDate == null)
                       .Select(i => i.InvoiceTemplate)
                       .FirstOrDefault();
            }
        }
    
        public virtual ICollection<InvoiceMembership> InvoiceMemberships { get; set;}
    }
