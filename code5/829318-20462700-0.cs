    DataTable dt = new DataTable();
    DataSet ds = new Dataset();
    BindingSource bs = new BindingSource();
    
    adapter.Fill(dt);
    ds = dt.Tables[0].DefaultView
    bs.DataSource = ds;
    aGridView.DataSource = bs.DataSource; 
