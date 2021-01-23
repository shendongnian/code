    //the DataGridView
    DataGridView dgView = new DataGridView();
    
    //BindingSource to sync DataTable and DataGridView
    BindingSource bSource = new BindingSource();
    
    //set the BindingSource DataSource
    bSource.DataSource = dTable;
    
    //set the DataGridView DataSource
    dgView.DataSource = bSource;
