    private List<Invoice> SearchInvoices(string sortOrder, string currentFilter, string searchString, int? page)
    {
        // do your search work here (as you were in your original index action)
        // I would actually have this whole method implemented
        // in a separate service/business layer
        // ..
        var invoices = from i in db.Invoices select i;
        // ..
        return invoices.ToPagedList(pageNumber, pageSize);
    } 
