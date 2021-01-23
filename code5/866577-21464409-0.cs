    List<string> invoiceIds = 
        (from invoice in db.Invoices_Parts
        where !invoice.IsClaimed && invoice.Invoice.IsPaid
        join part in partIds
        on invoice.PartId equals part into parts
        where parts.Any(part => part.IsActive)
        select invoice.InvoiceID)
        .Distinct()
        .ToList();
