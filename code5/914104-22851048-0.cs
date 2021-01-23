        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox2.Focus();
        }
