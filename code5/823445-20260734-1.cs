    private void ChangeDataSourceMode(DetailsViewMode newMode) {
        DetailsView1.ChangeMode(newMode);
        DetailsView1.DataSource = GetDetails.GetEmpDetailsById(Convert.ToInt32(Session["empId"]));
        DetailsView1.DataBind();
    }
    
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e) {
        ChangeDataSourceMode(e.NewMode);
    }
    
    protected void btnEdit_Click(object sender, EventArgs e) {
        ChangeDataSourceMode(DetailsViewMode.Edit);
    }
