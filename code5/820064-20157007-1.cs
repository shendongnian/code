        private void fudafrm_Load(object sender, EventArgs e)
        {
            this.Hide(); // not necessary from the Load() event
            Form f2 = new loginfrm();
            if (f2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage8);
            }
            else
            {
                Application.Exit(); // ?
            }
        }
