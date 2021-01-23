    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Rectangle bounds = e.Bounds;
            if (e.ColumnIndex == 0 && listView1.Columns[0].DisplayIndex != 0)
            {
                bounds = GetFirstColumnCorrectRectangle(e.Item);
            }
            e.Graphics.DrawString(e.SubItem.Text, Font, Brushes.Black, bounds);
        }
    
        private Rectangle GetFirstColumnCorrectRectangle(ListViewItem item)
        {
            int i;
            for (i = 0; i < listView1.Columns.Count; i++)
                if (listView1.Columns[i].DisplayIndex == listView1.Columns[0].DisplayIndex - 1)
                    break;
            return new Rectangle(item.SubItems[i].Bounds.Right, item.SubItems[i].Bounds.Y, listView1.Columns[0].Width, item.SubItems[i].Bounds.Height);
        }
