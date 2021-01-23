    public class order
    {
    public int orderID {get;set;}
    public int deliveryplaceID {get;set;}
    public int invoiceplaceID {get;set;}
    
    [ForeignKey("deliveryplaceID")]
    public virtual Place Deliveryplace {get;set;}
    [ForeignKey("invoiceplaceID")]
    public virtual Place Invoiceplace {get;set;}
    }
