            DataTable dtinput = new DataTable();
            DataTable dtquantity = new DataTable();
            dtinput.Columns.Add("id",typeof(int));
            dtinput.Rows.Add("2");
            dtinput.Rows.Add("4");
            dtinput.Rows.Add("7");
            
            dtquantity.Columns.Add("id", typeof(int));
            dtquantity.Columns.Add("qty", typeof(int));
            dtquantity.Rows.Add("1", "12");
            dtquantity.Rows.Add("2", "13");
            dtquantity.Rows.Add("3", "5");
            dtquantity.Rows.Add("4", "6");
            dtquantity.Rows.Add("7", null);
            var results = from table1 in dtinput.AsEnumerable()
                          join table2 in dtquantity.AsEnumerable()
                          on (int)table1["id"] equals (int)table2["id"]
                          into outer
                          from row in outer.DefaultIfEmpty<DataRow>()
                          select row;
            DataTable dt = results.CopyToDataTable();
