    private void myTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			string items = string.Empty;
			items += "Parent: "+((TreeViewItem)((TreeViewItem)myTree.SelectedItem).Parent).Header+"\n";
			items += "Children: \n";
			
			foreach (TreeViewItem tItem in ((TreeViewItem)myTree.SelectedItem).Items)
			{
				items += tItem.Header;
			}
			MessageBox.Show(items);
		}
