    public ServiceResponse<Invoice> CreateInvoiceForCustomer(Customer customer, IEnumerable<InvoiceItem> items, PaymentInfo paymentInfo)
    {
        using (var db = new MyContext())
        {
            db.Entry(customer).State = customer.ID == 0 : EntityState.Added : EntityState.Modified;
            
            var invoice = new Invoice
                {
                    Customer = customer,
                    InvoiceDate = _timeService.Now(),
                    PaymentInfo = paymentInfo
                };
            foreach (var item in items)
                invoice.Items.Add(items);
    
            db.Invoices.Add(invoice);
            db.SaveChanges();
    
            return new SeviceResponse<Invoice> 
                {
                    IsSuccess = true,
                    Data = invoice
                };
        }
     
    }
