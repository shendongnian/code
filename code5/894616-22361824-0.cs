        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo Root = new System.IO.DirectoryInfo(@"C:\");
            // treeView1.Nodes.Add("Local Disk");
            WalkDirectoryTree(Root);
            treeView1.PathSeparator = @"\";
            PopulateTreeView(treeView1, paths, '\\');
            DriveInfo[] ListDrives = DriveInfo.GetDrives();
            foreach (DriveInfo Drive in ListDrives)
            {
                if (Drive.DriveType == DriveType.Removable)
               {
                    if (Drive.IsReady == true)
                    {
                        TreeNode node = new TreeNode(Drive.Name);
                        node.Tag = Drive;
                        WalkDirectoryTree(Drive.RootDirectory);
                        treeView2.PathSeparator = @"\";
                        PopulateTreeView(treeView2, paths, '\\');
                    }
                }
            }
        }
        //**************************************************************************************************
        List<string> paths = new List<string>();
        private void FullPath(string str)
        {
            paths.Add(str);
        }
        //**************************************************************************************************
        void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;
            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.lst");
            }
            catch (UnauthorizedAccessException e)
            {
                log.Add(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    FullPath(fi.DirectoryName);
                }
                subDirs = root.GetDirectories();
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
            }
        }
        //**************************************************************************************************
        private static void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
                lastNode = null;
            }
        }
    }
