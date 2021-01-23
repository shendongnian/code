            private async Task ProcessSearchAsync()
            {
    
                Data.SeekWCF seekWcf = new Data.SeekWCF();
                _ds = await seekWcf.SearchInvoiceAdminAsync(new Guid(cboEmployer.Value.ToString()), new Guid(cboGroup.Value.ToString()), txtSearchInvoiceNumber.Text, chkSearchLike.Checked, txtSearchFolio.Text, Convert.ToInt32(txtYear.Value));
                seekWcf.Dispose();
            }
