    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        ListView listView = (ListView)sender;
        // Check if e.Item is selected and the ListView has no focus.
        if (!listView.Focused && e.Item.Selected)
        {
            Rectangle bounds = e.Item.GetBounds(ItemBoundsPortion.Label);
            e.Graphics.FillRectangle(SystemBrushes.Highlight, bounds);
            TextRenderer.DrawText(e.Graphics, e.Item.Text, listView.Font, bounds, SystemColors.HighlightText,
                TextFormatFlags.SingleLine | TextFormatFlags.Left | TextFormatFlags.GlyphOverhangPadding);
        }
        else
            e.DrawDefault = true;
    }
