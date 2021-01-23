        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {
                comboBox2.SelectedValue = comboBox1.SelectedValue.ToString();
            }
        }
