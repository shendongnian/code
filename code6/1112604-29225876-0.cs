    DataTable t = new DataTable();
    a.Fill(t);
 
    DataColumn newCol = new DataColumn("NewColumn", typeof(string));
    newCol.AllowDBNull = true;
    t.Columns.Add(newCol);
    foreach (DataRow row in t.Rows)
    {
         row["NewColumn"] = "With String";
    }
    dataGridView1.DataSource = t;
