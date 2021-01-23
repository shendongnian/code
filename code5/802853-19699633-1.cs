    table = new DataTable();
    table.Columns.Add("Name");
    table.Columns.Add("Age", typeof(int));
    table.Rows.Add("Alex", 27);
    table.Rows.Add("Jack", 65);
    table.Rows.Add("Bill", 22);
    dataGridView1.DataSource = table;
