    public NodeCheck(TreeNode node) 
    {
        DirectoryInfo rootDir = new DirectoryInfo(node.FullPath);
        DirectoryInfo[] directories = rootDir.GetDirectories();
        int i = 0;
        foreach (DirectoryInfo directory in directories)
        {
            if (e.Node.Nodes[i++].Checked == true)
            {
                AL_ftp_filepath.Add(ftp_filePath.ToString());
            }
        }
    }
    private void C_B_After_Click_for_nodecheck(object sender, TreeViewEventArgs e)
    {
         NodeCheck(e.Node);
    }
    private void C_B_backupNowButton_Click(object sender, EventArgs e) 
    {
         TreeNode node ; 
         node = //Code to get the code that you need/selected one
         NodeCheck(node);
         C_R_treeViewShow();
    }
