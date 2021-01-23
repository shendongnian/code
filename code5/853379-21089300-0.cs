        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = checkBox1.Checked;
            checkBox3.Checked = false;
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            // this is not called when you set "Checked" programmatically
        }
