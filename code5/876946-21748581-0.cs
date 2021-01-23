	from I in db.Invoices
	join O in db.Orders on I.InvoiceId equals O.InvoiceId
	join C in db.Customers on I.CustId equals C.CustId
	join OD in db.OrderDriverExtraCharges on O.OrderNumberId equals OD.OrderNumberId into ODs 
	from OD in ODs.DefaultIfEmpty()
	join AC in db.AccessorialCharges on OD.AccessorialChargeId equals AC.AccessorialChargeId into ACs 
	from AS in ACs.DefaultIfEmpty()
	where I.InvoiceId == invoice.InvoiceId
	select new PrintInvoiceViewModel()
