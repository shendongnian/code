    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
        var bounds = e.Bounds;
        if (e.ColumnIndex == 0) {
            bounds = listView1.GetItemRect(e.ItemIndex, ItemBoundsPortion.ItemOnly);
        }
        e.Graphics.DrawString(e.SubItem.Text, Font, Brushes.Black, bounds);
    }
