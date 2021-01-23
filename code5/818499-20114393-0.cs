    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you Sure you want to Exit. Click Yes to Confirm and No to continue", "WinForm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (timer2.Enabled == true)
                    {
                        if (MessageBox.Show("Quit now will delete all the file of the current operation. Click Yes to Confirm and No to continue", "WinForm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //do your work here like delete files etc
                        }
                        else
                        {
                            e.Cancel = false;
                            return;
                        }
                    }
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
