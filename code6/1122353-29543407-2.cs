        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Country country = (Country)listBox1.SelectedValue;
            if (country != null)
            {
                country.f = textBox1.Text;
            }
        }
