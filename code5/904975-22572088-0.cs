    // -1 because you want to start at column 1
    var extractedValues = new object[dataGridView1.RowCount, dataGridView1.ColumnCount - 1];  
    for (int row = 0; row < dataGridView1.RowCount; row++)
    {
      for (int col = 1; col < dataGridView1.ColumnCount; col++)
      {
        extractedValues[row, col -1] = dataGridView1.Rows[rows].Cells[col].Value;
      }
    }
