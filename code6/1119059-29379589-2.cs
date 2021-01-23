    foreach (DataGridViewColumn dgCol in dataGridView1.Columns)
    {
        foreach (DataGridViewRow dgRow in dataGridView1.Rows)
        {
            if (dgRow.Cells[dgCol.Name].Value != null) //Check for null reference
            {
                if (!string.IsNullOrEmpty(dgRow.Cells[dgCol.Name].Value.ToString())) //Check for empty string
                {
                    dgRow.Cells[dgCol.Name].Style.BackColor = Color.Orange;
                }
                else
                {
                    dgRow.Cells[dgCol.Name].Style.BackColor = Color.LightCyan;
                }
            }
        }
    }
