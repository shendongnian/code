        using (TransactionScope scope = new TransactionScope())
        {
            try
            {
                using (var DbContext = new CCTStoreEntities())
				{
					CCTInvoice invHead = new CCTInvoice();
					invHead.Name = Invoice.invoicename;
					invHead.Address = Invoice.invoiceaddress;
	
					DbContext.CCTInvoices.Add(invHead);
					DbContext.SaveChanges(false); // This is not needed
					_iid = invHead.InvoiceId;     // This is not needed
	
					foreach (InvoiceLine inLine in Invoice.Lines)
					{
						CCTInvoiceLine invLine = new CCTInvoiceLine();
						invLine.InvoiceNo = _iid; // This is not needed
						invLine.Quantity = inLine.lineqty;
						invLine.GrossPrice = inLine.linegrossprice;
						DbContext.CCTInvoiceLines.Add(invHead);
						DbContext.SaveChanges(false); // This is not needed
					}
	
					DbContext.SaveChanges();
					scope.Complete();
				}
            }
            catch
            {
                //Something went wrong
                //Rollback!
            }
        }
