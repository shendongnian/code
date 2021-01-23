        private void menuItem1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.FormClosing += f2_FormClosing;
            f2.Show();
            this.menuStrip1.Enabled = false;
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.FormClosing += f2_FormClosing;
            f2.Show();
            this.menuStrip1.Enabled = false;
        }
        void f2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.menuStrip1.Enabled = true;
        }
