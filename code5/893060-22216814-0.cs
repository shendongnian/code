      private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSourceChanged += dataGridView1_DataSourceChanged;
            List<MyClass> list = new List<MyClass>();
            list.Add(new MyClass { ID = 1, Name = "1", Date = DateTime.Now });
            list.Add(new MyClass { ID = 2, Name = "2", Date = DateTime.Now });
            list.Add(new MyClass { ID = 3, Name = "3", Date = DateTime.Now });
            list.Add(new MyClass { ID = 4, Name = "4", Date = DateTime.Now.AddDays(1) });
            dataGridView1.DataSource = list;
        }
        void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            // Loop through all the cells where date is in future
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((row.Cells[2].Value != null) && (DateTime)row.Cells[2].Value > DateTime.Now)
                {
                    row.Cells[2].Style.BackColor = Color.Blue;
                }
            }
        }
