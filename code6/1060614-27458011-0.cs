    private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                int length = chktb.Items.Count;
                for (int le = 0; le < length; le++)
                {
                    chktb.SetSelected(le, true);
                    chktb.SetItemChecked(le, true);
                }
                checkBox1.Checked = true;
            }
            else 
            {
                int length = chktb.Items.Count;
                for (int le = 0; le < length; le++)
                {
                    chktb.SetSelected(le, false);
                    chktb.SetItemChecked(le, false);
                }
                checkBox1.Checked = false;
            
            }
        }
