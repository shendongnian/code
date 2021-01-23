    [NotMapped]
    public InvoiceTemplate CurrentTemplate
    {
        get
        {
            using (var context = new MedicalContext())
                return context.InvoiceMemberships
                              .Where(m => m.SourceId == this.ID)
                              .Where(m => m.EndDate == null)
                              .Select(m => m.InvoiceTemplate)
                              .FirstOrDefault();
        }
    }
