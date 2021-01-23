            DataSet dst = new DataSet("Jobs");
            DataTable table = new DataTable("Job");
            
            DataColumn c1 = new DataColumn("Title");
            DataColumn c2 = new DataColumn("Date");
            table.Columns.Add(c1);
            table.Columns.Add(c2);
            DataRow row1 = table.NewRow();
            row1["Title"] = "T1";
            row1["Date"] = "D1";
            DataRow row2 = table.NewRow();
            row2["Title"] = "T2";
            row2["Date"] = "D2";
            table.Rows.Add(row1);
            table.Rows.Add(row2);
            dst.Tables.Add(table);
            string p = dst.GetXml();
