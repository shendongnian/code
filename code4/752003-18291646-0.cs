    private async void ProcessSearch()
    {
    
        Data.ConfigurationWCF confWcf = new Data.ConfigurationWCF();
    
        // get catalogs on first search
        if (_invoiceTypes == null && _invoiceAccounts == null)
        {
            _invoiceTypes = await confWcf.GetInvoiceTypesAsync(MainForm.State.Entity);
            _invoiceAccounts = await confWcf.GetInvoiceAccountsAsync(MainForm.State.Entity);
        }
    
        DataSeekWCF seekWcf = new DataSeekWCF();
        _ds = await seekWcf.SearchInvoiceAdminAsync(new Guid(cboEmployer.Value.ToString()), new Guid(cboGroup.Value.ToString()), txtSearchInvoiceNumber.Text, chkSearchLike.Checked, txtSearchFolio.Text, Convert.ToInt32(txtYear.Value));
    
        if (_ds != null && _invoiceTypes != null && _invoiceAccounts != null)
        {
            SetupInvoiceGrid();
        }
    
        confWcf.Dispose();
        seekWcf.Dispose();
    }
