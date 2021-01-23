    public void RemoveDirectoriesRecursive(TreeNode ParentNode, string path)
    {
        if (ParentNode.GetNodeCount(true) > 0)
        {
            foreach (TreeNode subnode in ParentNode.Nodes)
            {
                string ss = (string) subnode.Tag;
    
                if (ss.Equals("file"))
                {
                    DeleteFile(path + "\\" + subnode.Text, false);
                } 
                else if (ss.Equals("directory"))
                {
                    RemoveDirectoriesRecursive(subnode, path + "\\" + subnode.Text);
                    RemoveDirectory(path, true);
                }
            }
        }
    }
