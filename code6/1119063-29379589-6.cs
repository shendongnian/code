    foreach (DataGridViewRow dgRow in dataGridView1.Rows)
    {
        if (dgRow.Cells[7].Value != null) //Check for null reference
        {
            if (!string.IsNullOrEmpty(dgRow.Cells[7].Value.ToString())) //Check for empty string
            {
                dgRow.Cells[7].Style.BackColor = Color.Orange;
            }
            else
            {
                dgRow.Cells[7].Style.BackColor = Color.LightCyan;
            }
        }
    }
    
