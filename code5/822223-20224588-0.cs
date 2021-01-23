    ListViewItem lvi = new ListViewItem();
    string curItem = "curVal";
    
    int rowToPopulate = 0;
    int colToPopulate = 0;
    
    
    if (rowToPopulate <= listView2.Items.Count - 1)
    {
        lvi = listView2.Items[rowToPopulate];
        lvi.SubItems.Insert(colToPopulate, new ListViewItem.ListViewSubItem() { Text = curItem });
        listView2.Items[rowToPopulate] = lvi;
    }
    else
    {
        lvi.SubItems.Add(curItem);
        //Add all the other Subitems as usual
    
        listView2.Items.Add(lvi);
    }
