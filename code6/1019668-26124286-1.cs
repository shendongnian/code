    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0) //change 3 with your collumn index
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                
                if (dataGridView1 .Rows [e.RowIndex].IsNewRow )
                {
                   Bitmap bmp = Properties.Resources.myImage;
                
                   e.Graphics.DrawImage(bmp, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width, e.CellBounds.Height);
                 }
 
                 e.Handled = true;
            }
        }
