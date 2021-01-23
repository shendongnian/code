    private void DGV1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.Value == null) return;
        if (e.FormattedValue.GetType() != typeof( System.String) ) return;
        bool selected = (e.State & DataGridViewElementStates.Selected) 
                                == DataGridViewElementStates.Selected;
        string s = e.FormattedValue.ToString();
        //if (s.Length > 20) // Apply to all or only those breaking your limits
        {
            e.PaintBackground(e.CellBounds, selected);
            e.Graphics.DrawString(s, DGV1.Font, selected ? Brushes.White : Brushes.Black, 
                new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 2, 
                              e.CellBounds.Width - 2, e.CellBounds.Height - 4));
            e.Handled = true;
        }
    }
