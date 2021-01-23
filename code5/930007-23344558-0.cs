        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Application");
            comboBox1.Items.Add("Adobe");
            comboBox1.Items.Add("Flash");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox3.Enabled = comboBox4.Enabled = comboBox5.Enabled = false;
            if (comboBox1.Text != "Application")
                comboBox2.Items.Add("Application");
            if (comboBox1.Text != "Adobe")
                comboBox2.Items.Add("Adobe");
                comboBox2.Items.Add("Dreamweaver");
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox4.Enabled = comboBox5.Enabled = false;
            comboBox3.Enabled = true;
            if (comboBox2.Text != "Application")
                comboBox3.Items.Add("Application");
            if (comboBox2.Text != "Adobe")
                comboBox3.Items.Add("Adobe");
            comboBox2.Items.Add("Photoshop");
        }
