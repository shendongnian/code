        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            GetFilesAndFolder(e.Node, (string)e.Node.Tag);
        }
        private void GetFilesAndFolder(TreeNode tn, string Path)
        {
            try
            {
                string[] Directories = Directory.GetDirectories(Path);
                string[] Files = Directory.GetFiles(Path);
                foreach (string dir in Directories)
                {
                    TreeNode dirTreeNode = new TreeNode();
                    dirTreeNode.Tag = dir;
                    dirTreeNode.Text = new DirectoryInfo(dir).Name;
                    dirTreeNode.ImageIndex = GetIconOfFile_Folder(dir);
                    dirTreeNode.SelectedImageIndex = dirTreeNode.ImageIndex;
                    dirTreeNode.Nodes.Add(" ");
                    tn.Nodes.Add(dirTreeNode);
                }
                foreach (string file in Files)
                {
                    TreeNode fileTreeNode = new TreeNode();
                    fileTreeNode.Tag = file;
                    fileTreeNode.Text = new FileInfo(file).Name;
                    fileTreeNode.ImageIndex = GetIconOfFile_Folder(file);
                    fileTreeNode.SelectedImageIndex = fileTreeNode.ImageIndex;
                    tn.Nodes.Add(fileTreeNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
