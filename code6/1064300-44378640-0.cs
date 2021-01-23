    var InvoiceCollection = Service.GetInvoices();
    foreach (var invoice in InvoiceCollection)
    {   
        invoice.SendToCollectionIfNecessary();
    }
    
    // Invoice methods:
    public void SendToCollectionIfNecessary()
    {
        if (ShouldSendToCollection()) 
        {  
            SendToCollection();
        }
    }
    
    private bool ShouldSendToCollection() => currentInvoice.OverDue 
                                          && currentInvoice.NoticeSent 
                                          && !currentInvoice.InCollection;
