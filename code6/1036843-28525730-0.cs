    private void btnDelete_Click(object sender, EventArgs e)
            {
                try
                {
                    if (MessageBox.Show("I you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        impdg.Rows.RemoveAt(impdg.SelectedRows[0].Index);
                        dataAdapter.Update(dt1);
    
    
    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
