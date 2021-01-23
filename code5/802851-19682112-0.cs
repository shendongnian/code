    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
     // We are interested in handling the values in the "Description" column only..
     if (e.ColumnIndex == DescriptionDataGridViewTextBoxColumn.Index)
     {
         string description="something";
         if (e.Value != null)
         {
             if (e.Value.ToString()==description)
             {
                 e.CellStyle.ForeColor = e.CellStyle.BackColor;
                 e.CellStyle.SelectionForeColor = e.CellStyle.SelectionBackColor;
             }
         }
     }
    }
