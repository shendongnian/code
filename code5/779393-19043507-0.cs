            DataTable data = new DataTable();
            data.Columns.Add(new DataColumn("Value", typeof(string)));
            data.Columns.Add(new DataColumn("Description", typeof(string)));
            data.Rows.Add("item1","123");
            data.Rows.Add("item2","234");
            data.Rows.Add("item3","245");
            column.DataSource = data;
            column.ValueMember = "Value";
            column.DisplayMember = "Description";
           
            dataGridView1.Columns.Add(column);
