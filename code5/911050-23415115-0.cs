    foreach (SalesInvoiceSummary a in salesInvoiceSummary)
    {
    	summaryList.AppendLine("<b>Invoice number:</b> " + a.Key.Id + "  <b>Invoice amount:</b> " + a.TotalAmount.Value.ToString("C"));
    	
    	SalesInvoice invoice = wsDynamicsGP.GetSalesInvoiceByKey(a.Key.Id, context);
    	SalesInvoiceLine[] lineItems = invoice.Lines;
    }
