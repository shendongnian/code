    if (MessageBox.Show("Are you sure?", "Attention!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //this block will be executed when Yes is selected
                    MessageBox.Show("Data Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    //this block will be executed when No is selected
                }
