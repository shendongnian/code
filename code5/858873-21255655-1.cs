    //init your DataGridViews
    DataGridView grv1 = new DataGridView();
    DataGridView grv2 = new DataGridView();
    foreach (DataGridViewRow row1 in grv1.Rows)
    {
        foreach (DataGridViewRow row2 in grv2.Rows)
        {
            bool duplicateRow = true;
            for (int cellIndex = 0; cellIndex < row1.Cells.Count; cellIndex++)
            {
                if (!row1.Cells[cellIndex].Value.Equals(row2.Cells[cellIndex].Value))
                {
                    duplicateRow = false;
                    break;
                }
            }
    
            if (duplicateRow)
            {
                row1.DefaultCellStyle.BackColor = Color.Red;
                row2.DefaultCellStyle.BackColor = Color.Red;
            }
        }
    }
