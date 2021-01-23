    private void btnDown_Click(object sender, RoutedEventArgs e)
		{
			if ((TreeViewItem)((TreeViewItem)myTree.SelectedItem).Parent != null)
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
		private void btnUp_Click(object sender, RoutedEventArgs e)
		{
			if ((TreeViewItem)((TreeViewItem)myTree.SelectedItem).Parent != null)
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
