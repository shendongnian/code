        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                checkBox2.Checked = !checkBox2.Checked;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Visible = !checkBox1.Visible;
        }
