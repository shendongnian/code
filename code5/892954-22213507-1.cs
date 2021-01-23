	public TreeView ConvertToTreeView(Node node)
	{
		return new TreeView
                {
                    Id = node.AutoIncrementId;
                    Text = node.Text;
                    Items = node.Nodes != null
                               ? node.Nodes.Select(ConvertToTreeView).ToList()
                               : new List<TreeView>()
                };
	}
