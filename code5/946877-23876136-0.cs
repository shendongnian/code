     public static MainWindow _this;
            
            public MainWindow()
            {
                InitializeComponent();
                _this = this;
                
            }
            public void updateUsersInConversation(string username)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = username;
                //contactsTree.Children.Add(item);
            }
            public  static MainWindow GetInstance()
            {
                return _this;
            }
