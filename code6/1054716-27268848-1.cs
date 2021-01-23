       protected static void BindDataGridView(DataGridView grid, Object dataSource)
        {
            BindingSource bs = new BindingSource();
    
            bs.DataSource = dataSource;
    
            grid.DataSource = bs.DataSource; 
            
            grid.DataBind();
        }
