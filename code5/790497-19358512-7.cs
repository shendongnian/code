    private void btnDown_Click(object sender, RoutedEventArgs e)
		{
			if (!(((TreeViewItem)myTree.SelectedItem).Parent is TreeView))
			{
				ItemCollection nodes = ((TreeViewItem)((TreeViewItem)myTree.SelectedItem).Parent).Items;
				for (int i = 0; i < nodes.Count; i++)
				{
					if (nodes[i].Equals(myTree.SelectedItem))
					{
						try
						{
							if (i < nodes.Count - 1)
							{
								((TreeViewItem)nodes[i + 1]).IsSelected = true;
							}
							else
							{
								if (((TreeViewItem)myTree.SelectedItem).Items.Count != 0)
								{
									((TreeViewItem)((TreeViewItem)myTree.SelectedItem).Items[0]).IsSelected = true;
								}
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
						break;
					}
				}
			}
			else
			{
				if (((TreeViewItem)myTree.SelectedItem).Items.Count > 0)
				{
					((TreeViewItem)((TreeViewItem)myTree.SelectedItem).Items[0]).IsSelected = true;
				}				
			}
		}
		private void btnUp_Click(object sender, RoutedEventArgs e)
		{
			if (!(((TreeViewItem)myTree.SelectedItem).Parent is TreeView))
			{
				ItemCollection nodes = ((TreeViewItem)((TreeViewItem)myTree.SelectedItem).Parent).Items;
				for (int i = 0; i < nodes.Count; i++)
				{
					if (nodes[i].Equals(myTree.SelectedItem))
					{
						try
						{
							if (i > 0)
							{
								((TreeViewItem)nodes[i - 1]).IsSelected = true;
							}
							else
							{
								((TreeViewItem)((TreeViewItem)nodes[i]).Parent).IsSelected = true;
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
						break;
					}
				}
			}
		}
