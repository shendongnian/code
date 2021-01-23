    var OverDue = new OverDueSpecification();
    var NoticeSent = new NoticeSentSpecification();
    var InCollection = new InCollectionSpecification();
    
    // example of specification pattern logic chaining
    var SendToCollection = OverDue.And(NoticeSent).And(InCollection.Not());
    
    var InvoiceCollection = Service.GetInvoices();
    
    foreach (var currentInvoice in InvoiceCollection) {
        if (SendToCollection.IsSatisfiedBy(currentInvoice))  {
            currentInvoice.SendToCollection();
        }
    }
