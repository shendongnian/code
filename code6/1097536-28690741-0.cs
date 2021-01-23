     public viewmodel()
     {
            var tb = new DataTable("Table1");
            tb.Columns.Add("Status");
            tb.Columns.Add("Name");
            tb.Rows.Add("OK", "name1");
            tb.Rows.Add("ERROR", "name2");
            tb.Rows.Add("ERROR", "name3");
            Collection2 = new DataSet();
            Collection2.Tables.Add(tb);
     }
