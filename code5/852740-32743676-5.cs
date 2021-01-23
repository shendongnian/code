    MyNameSpace.External.FreeAgent FA = new ClientZone.External.FreeAgent("abcdefghhijklmnopqrstu", "1234567890123456789012", "acme", "http://localhost:52404/Invoice/Auth");
    int newID = FA.CreateInvoice(54321, InvoiceDate, 30, "", "", "GBP");
    if (newID != -1)
    {
        FA.CreateInvoiceItem(newID, unit, rate, quantity, number, description);
    }
