    ListViewItem listViewItem = this.listView1.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
    if (listViewItem != null)
    {
    	string firstColumn = listViewItem.Text;
    	string secondColumn = listViewItem.SubItems[0].Text;
    	// and so on with the SubItems
    }
