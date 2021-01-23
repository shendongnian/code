            var test = from row in table.AsEnumerable()
                       where (!row.IsNull("col1") || !row.IsNull("col2"))
                       select row;
            //option1
            DataTable dt = test.CopyToDataTable<DataRow>();
            //option2
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("col1", typeof(String));
            dt2.Columns.Add("col2", typeof(Int32));
            foreach (var v in test)
            {
                DataRow dr = dt2.NewRow();
                dr["col1"] = v.Field<String>("col1");
                dr["col1"] = v.Field<Int32>("col2");
                dt2.Rows.Add(dr);
            }
