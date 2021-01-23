     ListView.SelectedListViewItemCollection breakfast = 
			this.listview1.SelectedItems;
		
		double price = 0.0;
		foreach ( ListViewItem item in breakfast )
		{
			price += Double.Parse(item.SubItems[1].Text);
                        listview1.Items.Remove(item.SelectedItems[0]); 
		}
