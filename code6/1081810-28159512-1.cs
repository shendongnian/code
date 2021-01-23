        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            foreach(Control ctl in MyControls)
            {
                ctl.Visible = false; // or something else
            }
        }
