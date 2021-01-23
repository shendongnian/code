    if (listView1.SelectedItems.Count == 1)
    {
        int iIndex = listView1.FocusedItem.Index;
        if (iIndex >= 0)
        {
            ListViewItem oListViewItem = (ListViewItem)listView1.FocusedItem.Clone();
            listView1.SelectedItems[0].Remove();
            listView1.Items.Add(oListViewItem);        
        }
    }
