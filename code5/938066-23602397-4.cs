        private void Form1_Shown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Rows.Add(1, "Male");
            dt.Rows.Add(2, "Female");
            var table = GetDataTable(@"C:\temp\1.txt");
            foreach (DataColumn column in table.Columns)
            {
                var columnName = column.ColumnName;
                DataGridViewColumn col;
                if (columnName == "Gender")
                {
                    var c1 = new DataGridViewComboBoxColumn();
                    c1.DataSource = dt;
                    c1.DisplayMember = "Name";
                    c1.ValueMember = "ID";
                    col = c1;
                }
                else
                {
                    col = new DataGridViewTextBoxColumn();
                }
                col.HeaderText = "Gender";
                col.DataPropertyName = columnName;
                dataGridView1.Columns.Add(col);
            }
            dataGridView1.DataSource = table;
        }
