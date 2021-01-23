    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e){
      if(e.Value == null) return;
      e.CellStyle.BackColor = ((DateTime)e.Value).TimeOfDay < DateTime.Now.TimeOfDay ?
                              Color.Gray : Color.Green;
    }
