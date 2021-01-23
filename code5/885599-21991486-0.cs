    DataTable table = new DataTable();
    table.Columns.Add("Check", typeof(bool));
    table.Columns.Add("Path", typeof(string));
    table.Columns.Add("Date", typeof(DateTime));
    table.Rows.Add(false, "", DateTime.Now);
    dataGridView2.DataSource = table;
