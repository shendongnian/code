        private void GetAllDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                TreeNode rootTreeNode = new TreeNode();
                rootTreeNode.Text = drive.Name;
                rootTreeNode.Tag = drive.Name;
                rootTreeNode.ImageIndex = GetIconOfFile_Folder(drive.Name);
                rootTreeNode.SelectedImageIndex = rootTreeNode.ImageIndex;
                rootTreeNode.Nodes.Add(" "); //Placeholder to enable expanding (+)
                treeView1.Nodes.Add(rootTreeNode);
            }
        }
