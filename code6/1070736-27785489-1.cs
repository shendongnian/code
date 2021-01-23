    // form level var with a default:
    Color hdrColor = SystemColors.Control;
    private void _DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        using (Brush hBr = new SolidBrush(hdrColor))
        {
            e.Graphics.FillRectangle(hBr, e.Bounds);
            e.DrawText();
        }
    }
