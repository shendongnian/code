    // add new columns to the data grid
    void AddColumns(string[] newColumnNames)
    {
        foreach (string name in newColumnNames)
        {
            grid.Columns.Add(new DataGridTextColumn { 
                // bind to a dictionary property
                Binding = new Binding("Custom[" + name + "]"), 
                Header = name 
            });
        }
    }
