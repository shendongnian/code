    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        ListViewHitTestInfo hit = listView1.HitTest(e.Location);
        // Use hit.Item
        // Use hit.SubItem
    }
