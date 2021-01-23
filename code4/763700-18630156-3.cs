    protected void EmpDetails_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                e.Cancel = true;// Prevent the paging 
    
        }
