    try
    {
        foreach (DataGridViewRow dgvc in dgResults.Rows.Cast<DataGridViewRow>().Where(g => g.Cells[5].Value.ToString() == "0"))
        {
            dgvc.DefaultCellStyle.ForeColor = Color.White;
        }
    }
    catch (Exception)
    {
    
    }
 
