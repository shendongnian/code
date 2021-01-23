            CheckBox tmp = (CheckBox)sender;
            foreach (CheckBox c in flowLayoutPanel1.Controls)
            {
                c.CheckedChanged -= chk_CheckedChanged;
                c.Checked = false;
            }
            tmp.Checked = true;
            foreach (CheckBox c in flowLayoutPanel1.Controls)
            {
                c.CheckedChanged += chk_CheckedChanged;
            }
