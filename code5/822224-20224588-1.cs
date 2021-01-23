    string curItem = "curVal";    
    int rowToPopulate = 0;
    int colToPopulate = 0;
    
    if (rowToPopulate <= listView2.Items.Count - 1)
    {
        //Editing an existing row/ListViewItem
        listView2.Items[rowToPopulate].SubItems.Insert(colToPopulate, new ListViewItem.ListViewSubItem() { Text = curItem });
    }
    else
    {
        //Adding a new row/ListViewItem
        ListViewItem lvi = new ListViewItem();
        lvi.SubItems.Add(curItem);
        //Add all the other Subitems as usual
    
        listView2.Items.Add(lvi);
    }
