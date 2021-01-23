    public void RemoveDirectoriesRecursive(TreeNode ParentNode, string path)
    {
        if (ParentNode.GetNodeCount(true) > 0)
        {
            // go over all the nodes
            foreach (TreeNode subnode in ParentNode.Nodes)
            {
                string ss = (string) subnode.Tag;
                
                // if the node is a file then delete it
                if (ss.Equals("file"))
                {
                    DeleteFile(path + "\\" + subnode.Text, false);
                } 
                
                // otherwise, if the node is a directory call the recursion
                else if (ss.Equals("directory"))
                {
                    RemoveDirectoriesRecursive(subnode, path + "\\" + subnode.Text);
                }
            }
        }
        // finally after we deleted inner files and directories
        // delete this directory as well
        RemoveDirectory(path, true);
    }
