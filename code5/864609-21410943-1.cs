    if (listView1.SelectedItems.Count == 1)
    {
        int iIndex = listView1.SelectedItems[0].Index;
        if (iIndex > 0)
        {
            ListViewItem oListViewItem = (ListViewItem)listView1.SelectedItems[0].Clone();
            listView1.SelectedItems[0].Remove();
            listView1.Items.Insert(iIndex -1, oListViewItem);
            listView1.Items[iIndex -1].Selected = true;
        }
    }
