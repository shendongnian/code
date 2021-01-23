    private TreeNode GetChildNode(DirectoryEntry entry)
    {
        TreeNode node = new TreeNode(entry.Name.Substring(entry.Name.IndexOf('=') + 1));
        foreach (DirectoryEntry childEntry in entry.Children)
        {
            if (ShouldAddNode(childEntry.SchemaClassName))
                node.Nodes.Add(GetChildNode(childEntry));
        }
        return node;
    }
