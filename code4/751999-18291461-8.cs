    private async void ProcessSearchAsync()
    {
    
        Data.ConfigurationWCF confWcf = new Data.ConfigurationWCF();
        Task</*typeof _invoiceTypes*/> t1;
        Task</*typeof _invoiceAccounts*/> t2;
            
        if (_invoiceTypes == null)
            t1 = confWcf.GetInvoiceTypesAsync(MainForm.State.Entity);
        else
        {
            var tsc1 = new TaskCompletionSource</*typeof _invoiceTypes*/>();
            t1 = tsc1.Task;
            tsc1.SetResult(_invoiceTypes);
        }
        if ( _invoiceAccounts == null )
            t2 = confWcf.GetInvoiceAccountsAsync(MainForm.State.Entity);
        else
        {
            var tsc2 = new TaskCompletionSource</*typeof _invoiceAccounts*/>();
            t2 = tsc2.Task;
            tsc2.SetResult(_invoiceAccounts);
        }
        
        DataSeekWCF seekWcf = new DataSeekWCF();
        Task</*typeof _ds*/> t3 = seekWcf.SearchInvoiceAdminAsync(new Guid(cboEmployer.Value.ToString()), new Guid(cboGroup.Value.ToString()), txtSearchInvoiceNumber.Text, chkSearchLike.Checked, txtSearchFolio.Text, Convert.ToInt32(txtYear.Value));
    
        await Task.WhenAll(new Task[] {t1, t2, t3});
        _invoiceTypes = t1.Result;
        _invoiceAccounts = t2.Result;
        ds = t3.Result;
    
        if (_ds != null)
        {
            SetupInvoiceGrid();
        }
    
        confWcf.Dispose();
        seekWcf.Dispose();
    }
