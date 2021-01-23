     public static Account _this;
            
            public Account()
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
            public  static Account GetInstance()
            {
                return _this;
            }
