            private void chkOne_CheckedChanged(object sender, EventArgs e)
            {
                if (chkTwo.Checked == true)
                {
                    chkTwo.Checked = !chkOne.Checked;
                }
            }
            private void chkTwo_CheckedChanged(object sender, EventArgs e)
            {
                if (chkOne.Checked == true)
                {
                    chkOne.Checked = !chkTwo.Checked;
                }
            }
