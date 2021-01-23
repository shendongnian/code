        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = "";
                e.Handled = true;
            }
        }
