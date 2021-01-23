    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
       DataGridViewRow row = dataGridView1.Rows[i];
       for (int k = 0; k < row.Cells.Count; k++)
       {
          DataGridViewCell c = row.Cells[k];
          if (c.Value == null || c.Value.ToString() == String.Empty)
          {
             if (c.EditedFormattedValue == null || c.EditedFormattedValue.ToString() == "")
             {
                this.dataGridView1.Rows.RemoveAt(c.RowIndex);
                // Decrease i, as the collection got smaller
                i--;
                break;
              }
           }
        }
     }
