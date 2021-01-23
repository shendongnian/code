    using (var theForm = new CreateInvoice())
    {
        theForm.ShowDialog();
        if (theForm.Updated)
        {
            GetInvoiceStatus();
        }
    }
