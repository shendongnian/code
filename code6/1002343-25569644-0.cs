    dataGridView1.RowHeadersVisible = false;
    DataTable dt = new DataTable();
    dt.Columns.Add("Name");
    dt.Columns.Add("Address");
    dt.Rows.Add("ABC", "DEF");
    dt.Rows.Add("XYZ", "DEF");
    dt.Rows.Add("EFG", "HIJ");
    dataGridView1.DataSource = dt;
