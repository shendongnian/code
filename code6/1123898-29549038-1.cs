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
            node.ChildNodes.Add(child);
        }
        foreach (FileInfo file in folder.GetFiles("*.bch"))
        {
            var tn = new TreeNode(file.Name, file.FullName);
            node.ChildNodes.Add(tn);
        }
        return node;
    }
