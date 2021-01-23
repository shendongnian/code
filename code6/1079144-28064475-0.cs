	    var tree = sender as TreeView;
	    // ... Determine type of SelectedItem.
	    if (tree.SelectedItem is TreeViewItem)
	    {
		    // ... Handle a TreeViewItem.
		    var item = tree.SelectedItem as TreeViewItem;
		    this.Title = "Selected header: " + item.Header.ToString();
	    }
	    else if (tree.SelectedItem is string)
	    {
		    // ... Handle a string.
		    this.Title = "Selected: " + tree.SelectedItem.ToString();
	    }
