    Intuit.Ipp.Data.Qbo.InvoiceHeader invoiceHeader = new     Intuit.Ipp.Data.Qbo.InvoiceHeader();
    invoiceHeader.DocNumber = "AUTO_GENERATE";
    invoiceHeader.TxnDate = new DateTime(2013, 09, 04);
    invoiceHeader.TxnDateSpecified = true;
    invoiceHeader.CustomerId = new Intuit.Ipp.Data.Qbo.IdType() { idDomain =     Intuit.Ipp.Data.Qbo.idDomainEnum.QBO, Value = "12" };
    invoiceHeader.SubTotalAmt = 100;
    invoiceHeader.SubTotalAmtSpecified = true;
    invoiceHeader.TotalAmt = 100;
    invoiceHeader.TotalAmtSpecified = true;
 
    invoice.Header = invoiceHeader;
 
    Intuit.Ipp.Data.Qbo.InvoiceLine invoiceLine = new Intuit.Ipp.Data.Qbo.InvoiceLine();
    invoiceLine.Desc = "Description";
    invoiceLine.Amount = 100;
    invoiceLine.AmountSpecified = true;
    invoiceLine.Taxable = false;
    invoiceLine.TaxableSpecified = true;
    invoiceLine.ItemsElementName = new Intuit.Ipp.Data.Qbo.ItemsChoiceType2[] {     Intuit.Ipp.Data.Qbo.ItemsChoiceType2.ItemId,     Intuit.Ipp.Data.Qbo.ItemsChoiceType2.UnitPrice, Intuit.Ipp.Data.Qbo.ItemsChoiceType2.Qty };
    invoiceLine.Items = new object[] { new Intuit.Ipp.Data.Qbo.IdType() { idDomain = Intuit.Ipp.Data.Qbo.idDomainEnum.QBO, Value = "30" }, 100m, 1m };
 
    invoice.Line = new Intuit.Ipp.Data.Qbo.InvoiceLine[] { invoiceLine };
 
    Intuit.Ipp.Data.Qbo.Invoice addedInvoice = dataService.Add<Intuit.Ipp.Data.Qbo.Invoice>(invoice);
