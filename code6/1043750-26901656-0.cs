            public TrayMenu()
        {
            InitializeComponent();
            TrayMenuContext();
        }
        private void TrayMenuContext()
        {
            this.notify_icon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notify_icon.ContextMenuStrip.Items.Add("Test1", null, this.MenuTest1_Click);
            this.notify_icon.ContextMenuStrip.Items.Add("Test2", null, this.MenuTest2_Click);
            this.notify_icon.ContextMenuStrip.Items.Add("Exit", null, this.MenuExit_Click);
        }
		
        void MenuTest1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void MenuTest2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
