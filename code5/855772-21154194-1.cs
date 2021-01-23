    List<InvoiceJoin> data = (from invoice in db.TblInvoices
                              join client in db.TblClients
                              on  invoice.ReceiverCode equals client.client 
                              select new{Invoice=invoice,Client=client}).ToList() 
                              .Select(n=>new InvoiceJoin(n.Invoice,n.Client)).ToList()
