    private void dgvVendorDetails_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
    {
    	if (e.Column.Name == "CompanyID")
    		dgvVendorDetails.Columns("CompanyID").Visible = false;
    }
