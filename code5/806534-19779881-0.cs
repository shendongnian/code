    private void dgResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        try
        {
            foreach (DataGridViewCell dgvc in dgResults.Rows.Cast<DataGridViewRow>().Where(g => g.Cells[5].Value.ToString() == "0").SelectMany(g => g.Cells.Cast<DataGridViewCell>()))
            {
                dgvc.Style.ForeColor = Color.White;
            }
        }
        catch (Exception)
        {
    
        }
    }
