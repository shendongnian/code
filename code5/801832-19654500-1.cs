            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            
            DataRow row;
            row = dt.NewRow();
            row["Column1"] = "Hello";
            row["Column2"] = "World";
            dt.Rows.Add(row);
            dataGridView1.DataSource = dt;
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            dataGridView1.Columns[0].CellTemplate = cell;
