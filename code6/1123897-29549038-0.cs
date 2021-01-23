    private void PopulateTree()
    {
        var rootFolder = new DirectoryInfo(@"C:\inetpub\wwwroot\yourwebproject");
        var root = AddNodeAndDescendents(rootFolder);
        TreeView1.Nodes.Add(root);
    }
    private TreeNode AddNodeAndDescendents(DirectoryInfo folder)
    {
        var node = new TreeNode(folder.Name, folder.Name);
        var subFolders = folder.GetDirectories();
        foreach (DirectoryInfo subFolder in subFolders)
        {
            var child = AddNodeAndDescendents(subFolder);
            foreach (FileInfo file in subFolder.GetFiles("*.bch"))
            {
                var tn = new TreeNode(file.Name, file.FullName);
                child.ChildNodes.Add(tn);
            }
            node.ChildNodes.Add(child);
        }
        return node;
    }
