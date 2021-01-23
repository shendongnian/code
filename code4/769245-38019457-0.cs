    DataTable dt = empData.loadEmployee();
    BindingSource bs = new BindingSource();
    bs.DataSource = dt.AsEnumerable()
        .Where(c => c.Field<string>("First Name").ToLower()
        .Contains(txtSearch.Text.ToLower())).AsDataView();
                        
    dgvEmpManag.DataSource = bs;
