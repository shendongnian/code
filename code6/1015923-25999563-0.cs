    if (isFinalized)
    {
        invoices = invoices.Where(l => l.Invoices_Products.All(m => m.IsFinalized == true));
    }
    else
    {
        List<Invoice> finalizedInvoices = invoices.Where(l => l.Invoices_Products.All(m => m.IsFinalized == true)).ToList();
        invoices = invoices.Except(finalizedInvoices);
    }
