    Button button = new Button(){Width = 20, Height = 20};
    int maxHeight = 20;
    button.Parent = dataGridView1;//place this in your form constructor
    //CellPainting event handler for both your grids
    private void dataGridViews_CellPainting(object sender,
                                            DataGridViewCellPaintingEventArgs e) {
      DataGridView grid = sender as DataGridView;
      if (grid.CurrentCell.RowIndex == e.RowIndex &&
          grid.CurrentCell.ColumnIndex == e.ColumnIndex) {
         button.Top = e.CellBounds.Top - 2;
         button.Left = e.CellBounds.Right - button.Width;
         button.Height = Math.Min(e.CellBounds.Height, maxHeight);
         button.Invalidate();
      }
    }
    //Enter event handler for both your grids
    private void dataGridViews_Enter(object sender, EventArgs e){
      button.Parent = (sender as Control);
    }
