        private void treeviewContextMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            TreeViewItem selectedTreeViewItem = e.Source as TreeViewItem;
            string selectedTreeViewItemHeader = selectedTreeViewItem.Header.ToString();
			if (fe.ContextMenu != null)
            {
				if (selectedTreeViewItemHeader == "Clients")
				{
					fe.ContextMenu = TreeViewContextMenuIfTopLevelSelected();
				}
				else
				{
					MessageBox.Show("no menu to display");
				}
			}
			else
			{
				e.Handled = true;
				if (selectedTreeViewItemHeader == "Clients")
				{
					fe.ContextMenu = TreeViewContextMenuIfTopLevelSelected();
					fe.ContextMenu.IsOpen = true;
				}
				else
				{
					fe.ContextMenu = TreeViewContextMenu();
					fe.ContextMenu.IsOpen = true;
				}
			}
        }
