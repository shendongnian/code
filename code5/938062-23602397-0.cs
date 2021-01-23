            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Rows.Add(1, "Male");
            dt.Rows.Add(2, "Female");
            var lines = File.ReadAllLines(@"C:\Users\1\Desktop\1.txt");
            if (lines.Count() > 0)
            {
                foreach (var columnName in lines.FirstOrDefault()
                    .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (columnName == "Gender")
                    {
                        var c1 = new DataGridViewComboBoxColumn();
                        c1.DataSource = dt;
                        c1.DisplayMember = "Name";
                        c1.ValueMember = "ID";
                        c1.HeaderText = "Gender";
                        dataGridView1.Columns.Add(c1);
                        continue;
                    }
                    dataGridView1.Columns.Add(columnName, columnName);
                }
                foreach (var cellValues in lines.Skip(1))
                {
                    var cellArray = cellValues
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (cellArray.Length == dataGridView1.Columns.Count)
                        dataGridView1.Rows.Add(cellArray);
                }
            }
