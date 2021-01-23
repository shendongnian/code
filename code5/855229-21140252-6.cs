    DataTable dt = db.GetDataTable(Program.CONN, "SELECT ID FROM table WHERE column LIKE 'False%'");
    using (DataTableReader dtr = dt.CreateDataReader())
    {
        while (dtr.Read())
        {
            foreach (DataColumn col in dt.Columns)
            {
                string line = dtr[col.ColumnName].ToString();
                idList.Add(line);
            }
        }
    }
 
