    /* Create the DataGridView */
    matrix = new DataGridView();
    //modify behaviour
    matrix.ColumnHeadersVisible = false;
    // matrix.columnhea
    matrix.AllowUserToResizeColumns = false;
    matrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
    matrix.RowHeadersVisible = false;
    matrix.AllowUserToResizeRows = false;
    matrix.ReadOnly = true;
    //modify positioning
    matrix.Location = new Point(10, 20);
    //matrix.Dock = DockStyle.Fill;
    matrix.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
    //set the size of the matrix
    matrix.ColumnCount = cols;
    matrix.RowCount = rows;
    
    panel.Controls.Add(matrix);
    
    /* Set the data contents (not shown) */
    ...
    
    /* Adjust the width of columns */
    int width = 0;
    int height = 0;
    
    for(int c = 0; c < cols; c++) 
    {
      int largest = 0; //largest number of characters in cell
      for(int r = 0; r < rows; r++) 
      {
          int len = matrix.Rows[r].Cells[c].Value.ToString().Length;
          if (len > largest)
          {
              largest = len;
          }
      }
      matrix.Columns[c].Width = largest * 10;
      width += largest * 10;
    }
    
    /* Get height of table */
    foreach (DataGridViewRow row in matrix.Rows)
    {
        height += row.Height;
    }
    
    /* Set the DataGridView Size and Parent Panel size */
    //Note: first set the parent panel width, the table is anchored to all of its edges
    // as such table wont resize correctly if the panel isn't up to size first
    panel.Size = new Size(width + 20, height + 30);
    matrix.Size = new Size(width + 3, height + 3); //is it 1px per row and col?
    
    /* Parent Panel settings kept to default, no modifications */
