        private void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                int num = Int32.Parse(((TextBox)sender).Text), available = Int32.Parse(textBox1.Text);
                textBox1.Text = (available - num).ToString();
            }
            catch { }
        }
