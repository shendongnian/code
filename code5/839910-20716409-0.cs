    //CellClick event handler for the dataGridView1
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e){
      var colRect = dataGridView1.GetColumnDisplayRectangle(e.ColumnIndex, false);
      colRect.X = colRect.Right - dataGridView1.Columns[e.ColumnIndex].Width;
      int offSet = colRect.Right - dataGridView1.Width + 
                                   SystemInformation.VerticalScrollBarWidth;
      if (offSet < 0) {
         var rowHeaderWidth = !dataGridView1.RowHeadersVisible ? 0 : 
                               dataGridView1.RowHeadersWidth;
         offSet = colRect.Left < rowHeaderWidth ? colRect.Left - rowHeaderWidth : 0;
      }
      dataGridView1.HorizontalScrollingOffset += offSet;
    }
