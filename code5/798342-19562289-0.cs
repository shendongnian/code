            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("ColumnA",typeof(System.String)));
            DataRow row = dt2.NewRow();
            row["ColumnA"] = "LUZ"; 
            dt2.Rows.Add(row);
            row = dt2.NewRow();
            row["ColumnA"] = "PEPOTE";
            dt2.Rows.Add(row);
            int desiredIndex =
                dt2.AsEnumerable().ToList().
                FindIndex(r => !string.IsNullOrEmpty(r.Field<string>("ColumnA")) &&
                r.Field<string>("ColumnA").Length>3);
