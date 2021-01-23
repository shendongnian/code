    private void listViewOrders_MouseClick(object sender, MouseEventArgs e)
    {
        ListView listView = sender as ListView;
    
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
    
            if (item != null)
            {
                item.Selected = true;
                contextMenuStrip1.Tag = listView;
                contextMenuStrip1.Show(listView, e.Location);
            }
        }
    }
