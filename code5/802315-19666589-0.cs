    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        // expand the 3rd item in my treeview      
    	TreeViewItem tvi = treeView1.Items[2] as TreeViewItem;
    	if (tvi != null)
    	{
    		tvi.ExpandSubtree();
    	}
    }
