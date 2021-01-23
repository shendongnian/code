        public MainWindow()
        {
            InitializeComponent();
            StyleParents(MyTreeView.Items);
        }
        private void StyleParents(ItemCollection items)
        {
            foreach (var i in items)
            {
                TreeViewItem tvi = i as TreeViewItem;
                if (tvi != null)
                {
                    if (tvi.HasItems)
                    {
                        tvi.Foreground = Brushes.Magenta;
                        StyleParents(tvi.Items);
                    }
                }                                
            }
        }
