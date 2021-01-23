            DataTable dt = SampleData();
            int i = dt.Rows.Cast<DataRow>().TakeWhile(dr => dr != null && dr[1].ToString() != "2").Count();
            DataRow toInsert = dt.NewRow();
            dt.Rows.InsertAt(toInsert, i);
----------
            public DataTable SampleData()
            {
                DataTable dt=new DataTable();
                dt.Columns.Add("Hours",typeof(string));
                dt.Columns.Add("MA",typeof(string));
                dt.Columns.Add("Name",typeof(string));
                dt.Rows.Add(new object[] {@"10:00:00", 1, "Robert"});
                dt.Rows.Add(new object[] {@"10:30:00", 1, "Jane"});
                dt.Rows.Add(new object[] {@"11:15:00", 1, "John"});
                dt.Rows.Add(new object[] {@"14:00:00", 2, "Stewart"});
                dt.Rows.Add(new object[] {@"14:15:00", 2, "Elton"});
                return dt;
    
            }
