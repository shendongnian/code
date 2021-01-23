        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var t = (sender as TextBox);
            var s = t.Text.IndexOf(",");
            if (s > -1)
            {
                t.Text = t.Text.Replace(",", ".");
                t.SelectionStart = s+1;
            }
        }
