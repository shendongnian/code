    static long invoiceId = getMaxFunction();
    ...
    ...
    public long GenerateInvoiceId()
    {
        lock(this)
        {
            return invoiceId++;
        }
    }
