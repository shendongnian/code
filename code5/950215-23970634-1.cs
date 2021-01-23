    [HttpGet]
    public ViewResult Index()
    {
        var model = new IndexViewModel
        {
            // ..
            // call to private method SearchInvoices with default values
            Invoices = this.SearchInvoices("ASC", string.Empty, string.Empty, 0)
            //..
        };
        return this.View(model);
    }
