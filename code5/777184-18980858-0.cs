        private void button4_Click(object sender, EventArgs e)
        {
            List<DateTime> lstDate = new List<DateTime>();
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 40; i++)
            {
                lstDate.Add(dt);
            }
            comboBox1.DataSource = lstDate;
            comboBox1.FormatString = "M/dd/yyyy";
            comboBox1.FormattingEnabled = true;
        }
