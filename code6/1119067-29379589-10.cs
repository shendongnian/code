    foreach (DataGridViewRow dgRow in dataGridView1.Rows)
    {
        var cell = dgRow.Cells[7];
        if (cell.Value != null)   //Check for null reference
        {
            cell.Style.BackColor = string.IsNullOrEmpty(cell.Value.ToString()) ? 
                Color.LightCyan :   
                Color.Orange;       
        }
    }
