            DataTable dt = new DataTable();
            dt.Columns.Add("File_Name");
            dt.Columns.Add("Create_Date");
            dt.Columns.Add("Status");
            DataRow dr = dt.NewRow();
            dr["File_Name"] = "abc.txt";
            dr["Create_Date"] = DateTime.Now;
            dr["Status"] = "Pending";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["File_Name"] = "xyz.bmp";
            dr["Create_Date"] = DateTime.Now;
            dr["Status"] = "Complete";
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
