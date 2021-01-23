    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        const int TEXT_OFFSET = 1;    // I don't know why the text is located at 1px to the right. Maybe it's only for me.
        ListView listView = (ListView)sender;
        // Check if e.Item is selected and the ListView has a focus.
        if (!listView.Focused && e.Item.Selected)
        {
            Rectangle rowBounds = e.SubItem.Bounds;
            int leftMargin = e.Item.GetBounds(ItemBoundsPortion.Label).Left - TEXT_OFFSET;
            Rectangle bounds = new Rectangle(rowBounds.Left + leftMargin, rowBounds.Top, rowBounds.Width - leftMargin, rowBounds.Height);
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, listView.Font, bounds, SystemColors.HighlightText,
                TextFormatFlags.SingleLine | TextFormatFlags.Left | TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.VerticalCenter);
        }
        else
            e.DrawDefault = true;
    }
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        ListView listView = (ListView)sender;
        // Check if e.Item is selected and the ListView has a focus.
        if (!listView.Focused && e.Item.Selected)
        {
            Rectangle rowBounds = e.Bounds;
            int leftMargin = e.Item.GetBounds(ItemBoundsPortion.Label).Left;
            Rectangle bounds = new Rectangle(leftMargin, rowBounds.Top, rowBounds.Width - leftMargin, rowBounds.Height);
            e.Graphics.FillRectangle(SystemBrushes.Highlight, bounds);
        }
        else
            e.DrawDefault = true;
    }
