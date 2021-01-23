    private async void ProcessSearchAsync()
    {
    
        Data.ConfigurationWCF confWcf = new Data.ConfigurationWCF();
        Task</*typeof _invoiceTypes*/> t1;
        Task</*typeof _invoiceAccounts*/> t2;
    
        // get catalogs on first search
        if (_invoiceTypes == null && _invoiceAccounts == null)
        {
            t1 = confWcf.GetInvoiceTypesAsync(MainForm.State.Entity);
            t2 = confWcf.GetInvoiceAccountsAsync(MainForm.State.Entity);
        }
    
        DataSeekWCF seekWcf = new DataSeekWCF();
        Task</*typeof _ds*/> t3 = seekWcf.SearchInvoiceAdminAsync(new Guid(cboEmployer.Value.ToString()), new Guid(cboGroup.Value.ToString()), txtSearchInvoiceNumber.Text, chkSearchLike.Checked, txtSearchFolio.Text, Convert.ToInt32(txtYear.Value));
 
        _invoiceTypes = await t1;
        _invoiceAccounts = await t2;
        _ds = await t3;
        if (_ds != null)
        {
            SetupInvoiceGrid();
        }
    
        confWcf.Dispose();
        seekWcf.Dispose();
    }
