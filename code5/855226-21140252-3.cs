    DataTable dt = db.GetDataTable(Program.CONN, "SELECT ID FROM table WHERE column LIKE 'False%'");
    int count = dt.Columns.Count;
    using (DataTableReader dtr = dt.CreateDataReader())
    {
        while (dtr.Read())
        {
            for (int rt = 0 ; rt < count ; rt ++)
            {
                string line = dtr.GetValue(rt).ToString();
                idList.Add(line);
            }
         }
    }
       
 
