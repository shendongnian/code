    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
        ListView listView = (sender as Control).Tag as ListView;
        if (listViewOrders.SelectedItems.Count >= 1)
        {
            ...
