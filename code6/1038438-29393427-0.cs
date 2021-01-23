    static Icon m_errorIcon;
    public static Icon ErrorIcon
    {
        get
        {
            if (m_errorIcon == null)
            {
                ErrorProvider errorProvider = new ErrorProvider();
                m_errorIcon = errorProvider.Icon;
                errorProvider.Dispose();
            }
            return m_errorIcon;
        }
    }
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        try
        {
            if ((e.PaintParts & DataGridViewPaintParts.ErrorIcon) != 0 && !string.IsNullOrEmpty(e.ErrorText))
            {
                Icon icon = ErrorIcon;
                int pixelMargin = 2;
                Rectangle cellBounds = new Rectangle(e.CellBounds.X + pixelMargin, e.CellBounds.Y, e.CellBounds.Width - 2 * pixelMargin, e.CellBounds.Height);
                Rectangle firstIconRectangle = new Rectangle(cellBounds.Left, cellBounds.Top + Math.Max((cellBounds.Height - icon.Width) / 2, 0), Math.Min(icon.Width, cellBounds.Width), Math.Min(icon.Width, cellBounds.Height));
                e.Paint(e.ClipBounds, e.PaintParts & ~DataGridViewPaintParts.ErrorIcon);
                e.Graphics.DrawIcon(icon, firstIconRectangle);
                e.Handled = true;
            }
        }
        catch (Exception exception)
        {
        }
    }
