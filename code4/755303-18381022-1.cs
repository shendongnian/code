        private void button1_Click(object sender, EventArgs e)
        {
            var DBcontext = new DBDataContext();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Description";
            comboBox1.DataSource = DBcontext.Items.ToList();
            comboBox1.SelectedIndex = 0;
            DBcontext.Dispose();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Get displaytext
            MessageBox.Show(comboBox1.Text);
            
            //Get id value
            MessageBox.Show(comboBox1.SelectedValue.ToString()); 
        }
