    DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Browser", Type.GetType("System.String")), new DataColumn("userid", Type.GetType("System.String")) });
            dt.Rows.Add(new object[] {"Chrome-32.0","1" });
            dt.Rows.Add(new object[] { "Chrome-32.0", "1" });
            dt.Rows.Add(new object[] { "Firefox-20.0", "1" });
            dt.Rows.Add(new object[] { "Firefox-26.0", "1" });
            dt.Rows.Add(new object[] { "Safari", "1" });
            dt.Rows.Add(new object[] { "IE-9", "1" });
            dt.Rows.Add(new object[] { "IE-10", "1" });
            dt.Rows.Add(new object[] { "Chrome-31.0", "2" });
            dt.Rows.Add(new object[] { "Chrome-32.0", "1" });
            dt.Rows.Add(new object[] { "IE-10", "1" });
            dt.Rows.Add(new object[] { "Firefox-22.0", "2" });
            DataTable dtOutPut = new DataTable();
            dtOutPut.Columns.Add(new DataColumn("UserID", Type.GetType("System.String")));
            var tableColumnName = dt.AsEnumerable().Select(s => s.Field<string>("Browser").Trim().ToLower().Split('-')[0].Trim()).Distinct();
            foreach (var item in tableColumnName)
            {
                dtOutPut.Columns.Add(new DataColumn(item, Type.GetType("System.String")));
            }
            var usrid = dt.AsEnumerable().Select(s => s.Field<string>("userid").Trim()).Distinct();
            Parallel.ForEach(usrid, (s) => {
                DataRow rec = dtOutPut.NewRow();
                rec["UserID"] = s;
                foreach (var item in tableColumnName)
                {
                    rec[item] = dt.AsEnumerable().Where(s1 => s1.Field<string>("Browser").Trim().ToLower().Contains(item) && s1.Field<string>("userid") == s).Count();
                   
                }
                dtOutPut.Rows.Add(rec);
            });
