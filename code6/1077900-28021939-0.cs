            private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                var item = TV_Items.Nodes.Add(drive.Name);
                AddDirectories(item, drive.Name);
            }
        }
        private void AddDirectories(TreeNode parent, string path)
        {
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                try
                {
                    var subItem = parent.Nodes.Add(Path.GetDirectoryName(directory));
                    foreach (var file in Directory.GetFiles(directory))
                    {
                        subItem.Nodes.Add(Path.GetFileNameWithoutExtension(file));
                    }
                    AddDirectories(subItem, directory);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
