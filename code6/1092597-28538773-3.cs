    readonly Lazy<InvoiceTemplate> _currentTemplate;
    public Source()
    {
        _currentTemplate = new Lazy<InvoiceTemplate>(t => t = InvoiceMembership.ReadCurrentTemplate(ID));
    }
    [NotMapped]
    public InvoiceTemplate CurrentTemplate
    {
        get { return _currentTemplate.Value; }
    }
