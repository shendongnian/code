        private void button4_Click(object sender, EventArgs e)
        {
            List<DateTime> lstDate = new List<DateTime>();
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 20; i++)
            {
                lstDate.Add(dt);
            }
            List<string> lstDataSource = lstDate.Select(a => a.ToString("M/dd/yyyy")).ToList();
            lstDataSource.Insert(0, "---Select Date---");
            comboBox1.DataSource = lstDataSource;            
            comboBox1.FormattingEnabled = true;
            
        }
