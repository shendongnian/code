    public PartialViewResult Search(string sortOrder, string currentFilter, string searchString, int? page)
    {
        var invoices = this.SearchInvoices(sortOrder, currentFilter, searchString, page);
        return this.PartialView("_SearchContent", invoices);
    }
