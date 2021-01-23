    DataTreeNode<string> createFilteredTree(List<List<DataTreeNode<string>>> paths, List<int> types, List<bool> flags, string filter, string title)
		{
			DataTreeNode<string> root = new DataTreeNode<string> (new keyValuePair<string, int> ("SEARCH RESULTS", 0));
			foreach (List<DataTreeNode<string>> path in paths)
			{
				if (!passesFilter (path, types, flags, filter))
					continue;//don't need this path
				path.Reverse ();
				DataTreeNode<string> curNode = root;
				DataTreeNode<string> found;
				foreach (DataTreeNode<string> node in path)
				{
					found = curNode.FindTreeNode (node1 => node1.Data.Equals (node.Data));
					if (found == null)
					{
						found = node.Clone ();
						curNode.AddChild (found);
					}
					curNode = found;
				}
			}
			return root;
		}
