    //First we need to get all the non-empty cell values in some List<string>
    var cells = dataGridView1.Rows.Cast<DataGridViewRow>()
                  .Where(row=>!row.IsNewRow)
                  .SelectMany(row=>dataGridView1.Columns.Cast<DataGridViewColumn>()
                                   .Select(col=>row.Cells[col]))
                  .OrderBy(cell=>cell.ColumnIndex)
                  .ThenBy(cell=>cell.RowIndex)
                  .Where(cell=>Convert.ToString(cell.Value)!="").ToList();
    //update the cells to make the grid look like sorted
    for(int i = 0; i < dataGridView1.ColumnCount; i++){
      for(int j = 0; j < dataGridView1.RowCount; j++){
        if(dataGridView1.Rows[j].IsNewRow) continue;
        int k = i*dataGridView1.RowCount+j;
        dataGridView1[i,j].Value = k < cells.Count ? cells[k] : null;
      }
    }
                  
