    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        SetDetailsViewSource(e.NewMode);
    }
    
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        SetDetailsViewSource(DetailsViewMode.ReadOnly);
    }
