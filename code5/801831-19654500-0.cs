            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            
            DataRow row;
            row = dt.NewRow();
            row["Column1"] = "Hello";
            row["Column2"] = "World";
            dt.Rows.Add(row);
