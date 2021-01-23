    // DataGridView
    DataGridView dg = new DataGridView();
    
    // BindingSource (used for synchronizing table and grid)
    BindingSource bs = new BindingSource();
    
    // Set DataSource of BindingSource to table
    bs.DataSource = table;
    
    // Set grid DataSource
    dg.DataSource = bs;
