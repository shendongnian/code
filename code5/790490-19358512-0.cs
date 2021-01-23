    public partial class MainWindow : Window
	{
		private TreeView tree;
		string itemsHeaders = String.Empty;
		public MainWindow()
		{
			tree = new TreeView();
			TreeViewItem ceo = new TreeViewItem() { Header = "CEO" };
			TreeViewItem manager1 = new TreeViewItem() { Header = "Manager1" };
			TreeViewItem manager2 = new TreeViewItem() { Header = "Manager2" };
			TreeViewItem person1 = new TreeViewItem() { Header = "person1" };
			TreeViewItem person2 = new TreeViewItem() { Header = "person2" };
			manager1.Items.Add(person1);
			manager2.Items.Add(person2);
			ceo.Items.Add(manager1);
			ceo.Items.Add(manager2);
			tree.Items.Add(ceo);
			printTreeViewItems(tree.Items);
			MessageBox.Show(itemsHeaders);
				
		}
	
		public void printTreeViewItems(ItemCollection tree)
		{
			foreach (TreeViewItem tItem in tree)
			{
				itemsHeaders += "\t " + tItem.Header + " \n";
				if (tItem.Items.Count > 0)
				{
					printTreeViewItems(tItem.Items);
				}				
			}
		}
	}
