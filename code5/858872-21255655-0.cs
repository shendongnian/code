    foreach(var row1 in grv1.Rows)
    {
        foreach(var row2 in grv2.Rows)
        {
           bool duplicateRow = true;
           for (int cellIndex; cellIndex < row1.Cells.Count; cellIndex++)
           {
              if (!row1.Cells[cellIndex].Value.equals(row2.Cells[cellIndex].Value))
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
