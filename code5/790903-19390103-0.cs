     private void BTNDelete_Click(object sender, EventArgs e)
            {
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    
                    if (dr == DialogResult.Yes)
                    {
                        if (this.DVGAccounts.SelectedRows.Count >0 && this.DVGAccounts.SelectedRows[0].Index != this.DVGAccounts.Rows.Count -1)
                        {
                            this.DVGAccounts.Rows.RemoveAt(this.DVGAccounts.SelectedRows[0].Index);
                        }
    
    
                      
                    }
    
    
                }
            }
