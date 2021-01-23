    private void listView1_DrawColumnHeader(object sender, 
                                            DrawListViewColumnHeaderEventArgs e)
    {
        ColumnHeader ch = listView1.Columns[e.ColumnIndex];
        HorizontalAlignment colHal = ch.TextAlign;
        HorizontalAlignment headHal = colHal;
        // three headers that use a different alignment than the columns :
        if (e.ColumnIndex == 0) headHal = HorizontalAlignment.Center;
        if (e.ColumnIndex == 1) headHal = HorizontalAlignment.Right;
        if (e.ColumnIndex == 2) headHal = HorizontalAlignment.Left;
        SizeF size = e.Graphics.MeasureString(ch.Text, e.Font);
        float x = 
            headHal == HorizontalAlignment.Center ? ( e.Bounds.Width - size.Width ) / 2f :
            headHal == HorizontalAlignment.Right  ? ( e.Bounds.Width - size.Width ) : 0f;
        e.DrawBackground();
        using (SolidBrush brush = new SolidBrush(e.ForeColor) )
               e.Graphics.DrawString(ch.Text, e.Font, brush, 
                                     e.Bounds.X + x, 5f, StringFormat.GenericDefault);
    }
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        e.DrawDefault = true;
    }
