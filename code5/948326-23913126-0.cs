    var ip = new InvoiceProcessor
    {
        Customer = theCustomer,
        Order = theOrder
    };
    var invoice = ip.CreateInvoice();
    // Post processing
    HtmlPrinter.PrintInvoice(invoice, htmlFileName);
    DataAccess.SaveInvoice(invoice);
    MailService.SendInvoiceToCustomer(invoice, theCustomer.Email);
