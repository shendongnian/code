        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            foreach(Control ctl in MyControls)
            {
                ctl.Dispose();
            }
            MyControls.Clear();
        }
