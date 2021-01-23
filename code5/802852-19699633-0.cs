    DataTable table = new DataTable();
    table.Columns.Add("Name");
    table.Columns.Add("Age", typeof(int));
    table.Rows.Add("Alex", 27);
    table.Rows.Add("Jack", 65);
    table.Rows.Add("Bill", 22);
    table.DefaultView.Sort = "Name"; // Sorting is done here
    dataGridView1.DataSource = table;
