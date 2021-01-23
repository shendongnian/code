    DataTable items = new DataTable();
    items.Columns.Add("Backsn");
    items.Columns.Add("Oprn Name");
    for (int i = 0; i < dataGridView1.Rows.Count;i++ )
    {
       DataRow rw = items.NewRow();
       rw[0] = dataGridView1.Rows[i].Cells[2].Value.ToString();
       rw[1] = dataGridView1.Rows[i].Cells[8].Value.ToString();
       if (!items.Rows.Cast<DataRow>().Any(row => row["Backsn"].Equals(rw["Backsn"]) && row["Oprn Name"].Equals(rw["Oprn Name"])))
           items.Rows.Add(rw);
    }
