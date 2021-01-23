    **** This code is somewhere to fill the table ****
    DataTable table = new DataTable();
    foreach (line in file)
    {
        // Create connection to new server
        cnn = ...;
        // Append the results to the existing table
        AppendSqlResults(table, cnn);
    }
    // Set the source AFTER collecting all the data
    dataGridView.DataSource = table;
    **** This method appends the data to the table ****
    public void AppendSqlResults(DataTable table, SqlConnection cnn)
    { 
        cnn.Open();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(select, cnn);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        dataAdapter.Fill(table);
        cnn.Close();
    }
