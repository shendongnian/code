    DataTable table = new DataTable();
    //DataTable is filled with values here...
    DataGridView grid = new DataGridView();
    // assuming (this) is a reference to the current form
    this.Controls.Add(grid);
    
    grid.DataSource = table;
 
