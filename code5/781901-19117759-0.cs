    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {   
            if (e.ColumnIndex >= 0 && e.ColumnIndex < 1 && e.RowIndex >= 0)
            {
                //Watch out for the Index of Rows (here 0 for testing)
                string text = this.dataGridView1.Rows[0].Cells[e.ColumnIndex].Value.ToString();
                // Clear cell 
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), new Rectangle(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width / 10 , e.CellBounds.Height));
                e.Graphics.DrawString(text, this.Font, new SolidBrush(Color.Black), new Point(e.CellBounds.Left, e.CellBounds.Top + 2));
                e.Graphics.DrawRectangle(new Pen(Color.Silver), new Rectangle(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1));
                e.Handled = true;
            }
         
        }
