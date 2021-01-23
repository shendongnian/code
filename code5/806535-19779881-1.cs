    private void dgResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        try
        {
            foreach (DataGridViewRow dgvc in dgResults.Rows.Cast<DataGridViewRow>().Where(g => g.Cells[1].Value.ToString() == "2712"))
            {
                dgvc.DefaultCellStyle.ForeColor = Color.White;
            }
        }
        catch (Exception)
        {
    
        }
    }
