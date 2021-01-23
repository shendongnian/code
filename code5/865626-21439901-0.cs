    private void highlight_cell(object sender, System.Windows.Forms.PaintEventArgs e)
    {
       Control c = this.GetControlFromPosition(e.Column, e.Row);
        if ( c != null )
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(
				Pens.Red, 
				e.CellBounds.Location.X+1,
				e.CellBounds.Location.Y + 1,
				e.CellBounds.Width - 2, e.CellBounds.Height - 2);
			g.FillRectangle(
				Brushes.Red, 
				e.CellBounds.Location.X + 1, 
				e.CellBounds.Location.Y + 1, 
				e.CellBounds.Width - 2, 
				e.CellBounds.Height - 2);
                                       };
	   }
    }
