        class FileSystemObject
        {
            public FileSystemInfo FileSystemInfo;
            public FileSystemObjectType ObjectType;
            public bool SubNodesLoaded;
        }
        enum FileSystemObjectType
        {
            File = 1,
            Directory = 2
        }
        
        private void GetDrives()
        {
            DriveInfo[] drive = DriveInfo.GetDrives();
            foreach (DriveInfo d in drive)
            {
                drivenode = new TreeNode(d.Name);
                dir = d.RootDirectory;
                drivenode.Tag = new FileSystemObject { FileSystemInfo = dir, ObjectType = FileSystemObjectType.Directory };
                comp.Nodes.Add(drivenode);
                //drivenode.ImageIndex = 3;
                switch (d.DriveType)
                {
                    case DriveType.CDRom:
                        drivenode.ImageIndex = 5;
                        break;
                    //case DriveType.Fixed:
                    //    drivenode.ImageIndex = 1;
                    //    break;
                    case DriveType.Removable:
                        drivenode.ImageIndex = 8;
                        break;
                    //case DriveType.NoRootDirectory:
                    //    drivenode.ImageIndex = 5;
                    //    break;
                    case DriveType.Network:
                        drivenode.ImageIndex = 6;
                        break;
                    default:
                        drivenode.ImageIndex = 7;
                        break;
                }
                EnsureChildsLoaded(drivenode);
            }
        }
        private void EnsureChildsLoaded(TreeNode node)
        {
            try
            {
                FileSystemObject info = (FileSystemObject)node.Tag;
                if (info == null || info.ObjectType == FileSystemObjectType.File || info.SubNodesLoaded)
                {
                    return;
                }               
                DirectoryInfo dirInfo = (DirectoryInfo)info.FileSystemInfo;
                // while (!new DriveInfo(dirInfo.Root.FullName).IsReady)
                {
                    dirInfo.Refresh();
                }
                foreach (FileInfo fi in dirInfo.GetFiles())
                {
                    filenode = new TreeNode(fi.Name);
                    filenode.Name = fi.FullName;
                    //filenode.ImageIndex = 5;
                    getFileExtension(filenode.Name);
                    filenode.Tag = new FileSystemObject { FileSystemInfo = fi, ObjectType = FileSystemObjectType.File };
                    node.Nodes.Add(filenode);
                }
                foreach (DirectoryInfo di in dirInfo.GetDirectories())
                {
                    TreeNode dirnode = new TreeNode(di.Name);
                    dirnode.ImageIndex = 4;
                    dirnode.Name = di.FullName;
                    dirnode.Tag = new FileSystemObject { FileSystemInfo = di, ObjectType = FileSystemObjectType.Directory };
                    node.Nodes.Add(dirnode);
                }
                info.SubNodesLoaded = true;
            }
            catch (Exception ex){//log it }
        }
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //Load two level of nodes on demand
            FileSystemObject info = (FileSystemObject)e.Node.Tag;
            EnsureChildsLoaded(e.Node);
            foreach (TreeNode node in e.Node.Nodes)
            {
                EnsureChildsLoaded(node);
            }
        }
