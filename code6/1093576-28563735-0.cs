          BackgroundWorker bgworker = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            bgworker.DoWork += bgworker_DoWork;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo driveInfo in drives)
                trvStructure.Items.Add(CreateTreeItem(driveInfo));            
        }
        private void trvStructure_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            bgworker.RunWorkerAsync(item);
        }
        void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {          
            TreeViewItem item = (TreeViewItem)e.Argument;
            LoadFiles(item);           
        }
        void LoadFiles(TreeViewItem item)
        {
            System.Threading.Thread.Sleep(1000);
            item.Dispatcher.BeginInvoke(new Action<TreeViewItem>(AddItems), item);
        }      
      
        void AddItems(TreeViewItem item)
        {
            if ((item.Items.Count == 1) && (item.Items[0] is string))
            {
                item.Items.Clear();
                DirectoryInfo expandedDir = null;
                if (item.Tag is DriveInfo)
                    expandedDir = (item.Tag as DriveInfo).RootDirectory;
                if (item.Tag is DirectoryInfo)
                    expandedDir = (item.Tag as DirectoryInfo);
                try
                {
                    foreach (DirectoryInfo subDir in expandedDir.GetDirectories())
                    {
                        item.Items.Add(CreateTreeItem(subDir));
                    }
                }
                catch { }
            }
        }
        private TreeViewItem CreateTreeItem(object o)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = o.ToString();
            item.Tag = o;
            item.Items.Add("Loading...");
            return item;
        }      
      
