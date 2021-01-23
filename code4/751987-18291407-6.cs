    class InvoiceItem
    {
    	public string ItemName { get; set; }
    	public List<InvoiceOption> Options { get; set; }
    }
    
    class InvoiceOption
    {
    	public string OptionName { get; set; }
    }
