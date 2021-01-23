    if (e.ColumnIndex == yourColumnIndex)
    {
        // do your special stuff..
        e.Graphics.FillRectangle(Brushes.Wheat, e.CellBounds);
        // ..
        // now get the regular content drawn by the system
        e.PaintContent(e.CellBounds);  
        // and quit
        e.Handled = true;
    }
