    ListViewItem itemX;
    for (int i = 0; i < 10; i++)
    {
        itemX = new ListViewItem(i.ToString()); // First column
        itemX.SubItems.Add("Column 2")
        itemX.SubItems.Add("Column 3")
        itemX.SubItems.Add("Column 4")
        itemX.SubItems.Add("Column 5")
        itemX.SubItems.Add("Column 6")
        
        myListView.Items.Add(itemX); // Add the complete row to the ListView
    }
