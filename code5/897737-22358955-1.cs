    DataTable table = new DataTable();
    table.Columns.Add(...); // add "NAME" column
    table.Columns.Add(...); // add "DESCRIPTION" column
    // Create mapping of column names to text visible to the user
    Dictionary<string, string> cols = new Dictionary<string, string>()
    {
        { "NAME", "Name" },
        { "DESCRIPTION", "Description" }
    };
    // Call method:
    RegenerateColumns(MyGrid, table, cols);
    // Rebind the data to the grid
    MyGrid.DataSource = table;
    MyGrid.DataBind();
