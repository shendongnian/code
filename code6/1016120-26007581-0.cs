    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(TextBoxQuery.Text, strCon))
    using (SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter))
    {
        // Populate a new data table and bind it to the BindingSource.
        DataTable table = new DataTable();
        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        dataAdapter.Fill(table);
        dbBindSource.DataSource = table;
 
        // Resize the DataGridView columns to fit the newly loaded content.
        dbGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        // you can make it grid readonly.
        dbGridView.ReadOnly = true;
 
        // finally bind the data to the grid
        dbGridView.DataSource = dbBindSource;
    }
