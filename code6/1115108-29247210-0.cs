            Random rnd = new Random();
            
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("colDate", "Random Date");
            dataGridView1.Columns["colDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dataGridView1.Columns["colDate"].DataPropertyName = "Date";
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(DateTime));
            for (int i = 1; i <= 10; i++)
            {
                DataRow row = dt.NewRow();
                row["Date"] = DateTime.Now.AddDays(10 - rnd.Next(20));
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
